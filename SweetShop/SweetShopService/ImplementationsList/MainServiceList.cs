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
            int maxId = 0;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Requests[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
            }
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
            int index = -1;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Заказ не найден");
            }
            source.Requests[index].Status = RequestStatus.Готов;
        }

        public List<RequestViewModel> GetList()
        {
            List<RequestViewModel> result = new List<RequestViewModel>();
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                string CustomerFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].Id == source.Requests[i].CustomerId)
                    {
                        CustomerFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string CakeName = string.Empty;
                for (int j = 0; j < source.Cakes.Count; ++j)
                {
                    if (source.Cakes[j].Id == source.Requests[i].CakeId)
                    {
                        CakeName = source.Cakes[j].CakeName;
                        break;
                    }
                }
                string BakerFIO = string.Empty;
                if (source.Requests[i].BakerId.HasValue)
                {
                    for (int j = 0; j < source.Bakers.Count; ++j)
                    {
                        if (source.Bakers[j].Id == source.Requests[i].BakerId.Value)
                        {
                            BakerFIO = source.Bakers[j].BakerFIO;
                            break;
                        }
                    }
                }
                result.Add(new RequestViewModel
                {
                    Id = source.Requests[i].Id,
                    CustomerId = source.Requests[i].CustomerId,
                    CustomerFIO = CustomerFIO,
                    CakeId = source.Requests[i].CakeId,
                    CakeName = CakeName,
                    BakerId = source.Requests[i].BakerId,
                    BakerName = BakerFIO,
                    Count = source.Requests[i].Count,
                    Sum = source.Requests[i].Sum,
                    DateCreate = source.Requests[i].DateCreate.ToLongDateString(),
                    DateBaking = source.Requests[i].DateBaking?.ToLongDateString(),
                    Status = source.Requests[i].Status.ToString()
                });
            }
            return result;
        }

        public void PayRequest(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Заказ не найден");
            }
            source.Requests[index].Status = RequestStatus.Оплачен;
        }

        public void PutIngredientOnFridge(FridgeIngredientBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.FridgeIngredients.Count; ++i)
            {
                if (source.FridgeIngredients[i].FridgeId == model.FridgeId &&
                    source.FridgeIngredients[i].IngredientId == model.IngredientId)
                {
                    source.FridgeIngredients[i].Count += model.Count;
                    return;
                }
                if (source.FridgeIngredients[i].Id > maxId)
                {
                    maxId = source.FridgeIngredients[i].Id;
                }
            }
            source.FridgeIngredients.Add(new FridgeIngredient
            {
                Id = ++maxId,
                FridgeId = model.FridgeId,
                IngredientId = model.IngredientId,
                Count = model.Count
            });
        }

        public void TakeRequestInWork(RequestBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Requests.Count; ++i)
            {
                if (source.Requests[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Заказ не найден");
            }
            // смотрим по количеству компонентов на складах
            for (int i = 0; i < source.CakeIngredients.Count; ++i)
            {
                if (source.CakeIngredients[i].CakeId == source.Requests[index].CakeId)
                {
                    int countOnFridges = 0;
                    for (int j = 0; j < source.FridgeIngredients.Count; ++j)
                    {
                        if (source.FridgeIngredients[j].IngredientId == source.CakeIngredients[i].IngredientId)
                        {
                            countOnFridges += source.FridgeIngredients[j].Count;
                        }
                    }
                    if (countOnFridges < source.CakeIngredients[i].Count * source.Requests[index].Count)
                    {
                        for (int j = 0; j < source.Ingredients.Count; ++j)
                        {
                            if (source.Ingredients[j].Id == source.CakeIngredients[i].IngredientId)
                            {
                                throw new Exception("Не достаточно ингредиента " + source.Ingredients[j].IngredientName +
                                    " требуется " + source.CakeIngredients[i].Count + ", в наличии " + countOnFridges);
                            }
                        }
                    }
                }
            }
            // списываем
            for (int i = 0; i < source.CakeIngredients.Count; ++i)
            {
                if (source.CakeIngredients[i].CakeId == source.Requests[index].CakeId)
                {
                    int countOnFridges = source.CakeIngredients[i].Count * source.Requests[index].Count;
                    for (int j = 0; j < source.FridgeIngredients.Count; ++j)
                    {
                        if (source.FridgeIngredients[j].IngredientId == source.CakeIngredients[i].IngredientId)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (source.FridgeIngredients[j].Count >= countOnFridges)
                            {
                                source.FridgeIngredients[j].Count -= countOnFridges;
                                break;
                            }
                            else
                            {
                                countOnFridges -= source.FridgeIngredients[j].Count;
                                source.FridgeIngredients[j].Count = 0;
                            }
                        }
                    }
                }
            }
            source.Requests[index].BakerId = model.BakerId;
            source.Requests[index].DateBaking = DateTime.Now;
            source.Requests[index].Status = RequestStatus.Выполняется;
        }
    }
}
