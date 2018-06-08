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
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateRequest(RequestBindingModel model)
        {
            int maxId = source.Requests.Count > 0 ? source.Requests.Max(rec => rec.Id) : 0;

            source.Requests.Add(new Request
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                CakeId = model.CakeId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = RequestStatus.Принят
            });
        }

        public void FinishRequest(int id)
        {
            Request element = source.Requests.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Заказ не найден");
            }
            element.Status = RequestStatus.Готов;
        }

        public List<RequestViewModel> GetList()
        {
            List<RequestViewModel> result = source.Requests
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    CakeId = rec.CakeId,
                    BakerId = rec.BakerId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateBaking = rec.DateBaking?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    CustomerFIO = source.Customers
                                     .FirstOrDefault(recC => recC.Id == rec.CustomerId)?.CustomerFIO,
                    CakeName = source.Cakes
                                     .FirstOrDefault(recP => recP.Id == rec.CakeId)?.CakeName,
                    BakerName = source.Bakers
                                     .FirstOrDefault(recI => recI.Id == rec.BakerId)?.BakerFIO
                })
                 .ToList();
            return result;
        }

        public void PayRequest(int id)
        {
            Request element = source.Requests.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Заказ не найден");
            }
            element.Status = RequestStatus.Оплачен;
        }

        public void ReplenishFridge(FridgeIngredientBindingModel model)
        {
            FridgeIngredient element = source.FridgeIngredients
                                                .FirstOrDefault(rec => rec.FridgeId == model.FridgeId &&
 rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.FridgeIngredients.Count > 0 ? source.FridgeIngredients.Max(rec => rec.Id) : 0;
                source.FridgeIngredients.Add(new FridgeIngredient

                {
                    Id = ++maxId,
                    FridgeId = model.FridgeId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
        }

        public void TakeRequestInWork(RequestBindingModel model)
        {
            Request element = source.Requests.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Заказ не найден");
            }
            // смотрим по количеству компонентов на складах
            var CakeIngredients = source.CakeIngredients.Where(rec => rec.CakeId == element.CakeId);
            foreach (var CakeIngredient in CakeIngredients)
            {
                int countOnFridges = source.FridgeIngredients
                                             .Where(rec => rec.IngredientId == CakeIngredient.IngredientId)
                                             .Sum(rec => rec.Count);
                if (countOnFridges < CakeIngredient.Count * element.Count)
                {
                    var IngredientName = source.Ingredients
                                     .FirstOrDefault(rec => rec.Id == CakeIngredient.IngredientId);
                    throw new Exception("Не достаточно компонента " + IngredientName?.IngredientName +
" требуется " + CakeIngredient.Count + ", в наличии " + countOnFridges);

                }
            }
            // списываем
            foreach (var CakeIngredient in CakeIngredients)
            {
                int countOnFridges = CakeIngredient.Count * element.Count;
                var FridgeIngredients = source.FridgeIngredients
                                            .Where(rec => rec.IngredientId == CakeIngredient.IngredientId);
                foreach (var FridgeIngredient in FridgeIngredients)
                {
                    // компонентов на одном слкаде может не хватать
                    if (FridgeIngredient.Count >= countOnFridges)
                    {
                        FridgeIngredient.Count -= countOnFridges;
                        break;
                    }
                    else
                    {
                        countOnFridges -= FridgeIngredient.Count;
                        FridgeIngredient.Count = 0;
                    }
                }
            }
            element.BakerId = model.BakerId;
            element.DateBaking = DateTime.Now;
            element.Status = RequestStatus.Выполняется;
        }
    }
}
