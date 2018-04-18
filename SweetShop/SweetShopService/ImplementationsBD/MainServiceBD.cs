using SweetShop;
using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ImplementationsBD
{
    public class MainServiceBD : IMainService
    {
        private AbstractDbContext context;

        public MainServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<RequestViewModel> GetList()
        {
            List<RequestViewModel> result = context.Requests
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    CakeId = rec.CakeId,
                    BakerId = rec.BakerId,
                    DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                                    SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                                    SqlFunctions.DateName("yyyy", rec.DateCreate),
                    DateBaking = rec.DateBaking == null ? "" :
                                    SqlFunctions.DateName("dd", rec.DateBaking.Value) + " " +
                                    SqlFunctions.DateName("mm", rec.DateBaking.Value) + " " +
                                    SqlFunctions.DateName("yyyy", rec.DateBaking.Value),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    CustomerFIO = rec.Customer.CustomerFIO,
                    CakeName = rec.Cake.CakeName,
                    BakerName = rec.Baker.BakerFIO
                })
                .ToList();
            return result;
        }

        public void CreateRequest(RequestBindingModel model)
        {
            context.Requests.Add(new Request
            {
                CustomerId = model.CustomerId,
                CakeId = model.CakeId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = RequestStatus.Принят
            });
            context.SaveChanges();
        }

        public void TakeRequestInWork(RequestBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {

                    Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    var CakeIngredients = context.CakeIngredients
                                                .Include(rec => rec.Ingredient)
                                                .Where(rec => rec.CakeId == element.CakeId);
                    // списываем
                    foreach (var CakeIngredient in CakeIngredients)
                    {
                        int countOnFridges = CakeIngredient.Count * element.Count;
                        var FridgeIngredients = context.FridgeIngredients
                                                    .Where(rec => rec.IngredientId == CakeIngredient.IngredientId);
                        foreach (var FridgeIngredient in FridgeIngredients)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (FridgeIngredient.Count >= countOnFridges)
                            {
                                FridgeIngredient.Count -= countOnFridges;
                                countOnFridges = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnFridges -= FridgeIngredient.Count;
                                FridgeIngredient.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnFridges > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                                CakeIngredient.Ingredient.IngredientName + " требуется " +
                                CakeIngredient.Count + ", не хватает " + countOnFridges);
                        }
                    }
                    element.BakerId = model.BakerId;
                    element.DateBaking = DateTime.Now;
                    element.Status = RequestStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void FinishRequest(int id)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = RequestStatus.Готов;
            context.SaveChanges();
        }

        public void PayRequest(int id)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = RequestStatus.Оплачен;
            context.SaveChanges();
        }

        public void PutIngredientOnFridge(FridgeIngredientBindingModel model)
        {
            FridgeIngredient element = context.FridgeIngredients
                                                .FirstOrDefault(rec => rec.FridgeId == model.FridgeId &&
                                                rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.FridgeIngredients.Add(new FridgeIngredient
                {
                    FridgeId = model.FridgeId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
