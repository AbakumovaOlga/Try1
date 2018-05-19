using SweetShop;
using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ImplementationsBD
{
    public class CakeServiceBD : ICakeService
    {
        private AbstractDbContext context;

        public CakeServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<CakeViewModel> GetList()
        {
            List<CakeViewModel> result = context.Cakes
                .Select(rec => new CakeViewModel
                {
                    Id = rec.Id,
                    CakeName = rec.CakeName,
                    Price = rec.Price,
                    CakeIngredients = context.CakeIngredients
                            .Where(recPC => recPC.CakeId == rec.Id)
                            .Select(recPC => new CakeIngredientViewModel
                            {
                                Id = recPC.Id,
                                CakeId = recPC.CakeId,
                                IngredientId = recPC.IngredientId,
                                IngredientName = recPC.Ingredient.IngredientName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public CakeViewModel GetElement(int id)
        {
            Cake element = context.Cakes.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CakeViewModel
                {
                    Id = element.Id,
                    CakeName = element.CakeName,
                    Price = element.Price,
                    CakeIngredients = context.CakeIngredients
                            .Where(recPC => recPC.CakeId == element.Id)
                            .Select(recPC => new CakeIngredientViewModel
                            {
                                Id = recPC.Id,
                                CakeId = recPC.CakeId,
                                IngredientId = recPC.IngredientId,
                                IngredientName = recPC.Ingredient.IngredientName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CakeBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Cake element = context.Cakes.FirstOrDefault(rec => rec.CakeName == model.CakeName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Cake
                    {
                        CakeName = model.CakeName,
                        Price = model.Price
                    };
                    context.Cakes.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupIngredients = model.CakeIngredients
                                                .GroupBy(rec => rec.IngredientId)
                                                .Select(rec => new
                                                {
                                                    IngredientId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    // добавляем компоненты
                    foreach (var groupIngredient in groupIngredients)
                    {
                        context.CakeIngredients.Add(new CakeIngredient
                        {
                            CakeId = element.Id,
                            IngredientId = groupIngredient.IngredientId,
                            Count = groupIngredient.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(CakeBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Cake element = context.Cakes.FirstOrDefault(rec =>
rec.CakeName == model.CakeName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Cakes.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.CakeName = model.CakeName;
                    element.Price = model.Price;
                    context.SaveChanges();

                    // обновляем существуюущие компоненты
                    var compIds = model.CakeIngredients.Select(rec => rec.IngredientId).Distinct();
                    var updateIngredients = context.CakeIngredients
                                                    .Where(rec => rec.CakeId == model.Id &&
compIds.Contains(rec.IngredientId));
                    foreach (var updateIngredient in updateIngredients)
                    {
                        updateIngredient.Count = model.CakeIngredients
                                                        .FirstOrDefault(rec => rec.Id == updateIngredient.Id).Count;
                    }
                    context.SaveChanges();
                    context.CakeIngredients.RemoveRange(
                                        context.CakeIngredients.Where(rec => rec.CakeId == model.Id &&
                                                                            !compIds.Contains(rec.IngredientId)));
                    context.SaveChanges();
                    // новые записи
                    var groupIngredients = model.CakeIngredients
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.IngredientId)
                                                .Select(rec => new
                                                {
                                                    IngredientId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupIngredient in groupIngredients)
                    {
                        CakeIngredient elementPC = context.CakeIngredients
                                                .FirstOrDefault(rec => rec.CakeId == model.Id &&
rec.IngredientId == groupIngredient.IngredientId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupIngredient.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.CakeIngredients.Add(new CakeIngredient
                            {
                                CakeId = model.Id,
                                IngredientId = groupIngredient.IngredientId,
                                Count = groupIngredient.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Cake element = context.Cakes.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.CakeIngredients.RemoveRange(
                                            context.CakeIngredients.Where(rec => rec.CakeId == id));
                        context.Cakes.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
