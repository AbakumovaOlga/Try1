using SweetShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetShopService.BindingModels;
using SweetShopService.ViewModels;
using SweetShop;

namespace SweetShopService.ImplementationsList
{
    public class CakeServiceList : ICakeService
    {
        private DataListSingleton source;

        public CakeServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(CakeBindingModel model)
        {
            Cake element = source.Cakes.FirstOrDefault(rec => rec.CakeName == model.CakeName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Cakes.Count > 0 ? source.Cakes.Max(rec => rec.Id) : 0;
            source.Cakes.Add(new Cake
            {
                Id = maxId + 1,
                CakeName = model.CakeName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.CakeIngredients.Count > 0 ?
source.CakeIngredients.Max(rec => rec.Id) : 0;
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
                source.CakeIngredients.Add(new CakeIngredient
                {
                    Id = ++maxPCId,
                    CakeId = maxId + 1,
                    IngredientId = groupIngredient.IngredientId,
                    Count = groupIngredient.Count
                });
            }
        }

        public void DelElement(int id)
        {
            Cake element = source.Cakes.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.CakeIngredients.RemoveAll(rec => rec.CakeId == id);
                source.Cakes.Remove(element);
            }
            else
            {
                throw new Exception("Пироженое не найдено");
            }

        }

        public CakeViewModel GetElement(int id)
        {
            Cake element = source.Cakes.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CakeViewModel

                {
                    Id = element.Id,
                    CakeName = element.CakeName,
                    Price = element.Price,
                    CakeIngredients = source.CakeIngredients
                             .Where(recPC => recPC.CakeId == element.Id)
                             .Select(recPC => new CakeIngredientViewModel
                             {
                                 Id = recPC.Id,
                                 CakeId = recPC.CakeId,
                                 IngredientId = recPC.IngredientId,
                                 IngredientName = source.Ingredients
                                        .FirstOrDefault(recC => recC.Id == recPC.IngredientId)?.IngredientName,
                                 Count = recPC.Count
                             })
                             .ToList()
                };
            }

            throw new Exception("Пироженое не найдено");
        }

        public List<CakeViewModel> GetList()
        {
            List<CakeViewModel> result = source.Cakes
                .Select(rec => new CakeViewModel

                {
                    Id = rec.Id,
                    CakeName = rec.CakeName,
                    Price = rec.Price,
                    CakeIngredients = source.CakeIngredients
                             .Where(recPC => recPC.CakeId == rec.Id)
                             .Select(recPC => new CakeIngredientViewModel
                             {
                                 Id = recPC.Id,
                                 CakeId = recPC.CakeId,
                                 IngredientId = recPC.IngredientId,
                                 IngredientName = source.Ingredients
                                     .FirstOrDefault(recC => recC.Id == recPC.IngredientId)?.IngredientName,
                                 Count = recPC.Count
                             })
                            .ToList()
                })
                 .ToList();
            return result;
        }

        public void UpdElement(CakeBindingModel model)
        {
            Cake element = source.Cakes.FirstOrDefault(rec =>
  rec.CakeName == model.CakeName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Cakes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Пироженое не найдено");
            }
            element.CakeName = model.CakeName;
            element.Price = model.Price;

            int maxPCId = source.CakeIngredients.Count > 0 ? source.CakeIngredients.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.CakeIngredients.Select(rec => rec.IngredientId).Distinct();
            var updateIngredients = source.CakeIngredients
                                            .Where(rec => rec.CakeId == model.Id &&
compIds.Contains(rec.IngredientId));
            foreach (var updateIngredient in updateIngredients)
            {
                updateIngredient.Count = model.CakeIngredients
                                                .FirstOrDefault(rec => rec.Id == updateIngredient.Id).Count;

            }
            source.CakeIngredients.RemoveAll(rec => rec.CakeId == model.Id &&
!compIds.Contains(rec.IngredientId));
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
                CakeIngredient elementPC = source.CakeIngredients
                                         .FirstOrDefault(rec => rec.CakeId == model.Id &&
  rec.IngredientId == groupIngredient.IngredientId);
                if (elementPC != null)
                {
                    elementPC.Count += groupIngredient.Count;
                }
                else
                {
                    source.CakeIngredients.Add(new CakeIngredient
                    {
                        Id = ++maxPCId,
                        CakeId = model.Id,
                        IngredientId = groupIngredient.IngredientId,
                        Count = groupIngredient.Count
                    });
                }
            }
        }
    }
}
