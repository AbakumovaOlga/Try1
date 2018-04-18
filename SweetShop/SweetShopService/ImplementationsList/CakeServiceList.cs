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
            int maxId = 0;
            for (int i = 0; i < source.Cakes.Count; ++i)
            {
                if (source.Cakes[i].Id > maxId)
                {
                    maxId = source.Cakes[i].Id;
                }
                if (source.Cakes[i].CakeName == model.CakeName)
                {
                    throw new Exception("Уже есть пироженое с таким названием");
                }
            }
            source.Cakes.Add(new Cake
            {
                Id = maxId + 1,
                CakeName = model.CakeName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.CakeIngredients.Count; ++i)
            {
                if (source.CakeIngredients[i].Id > maxPCId)
                {
                    maxPCId = source.CakeIngredients[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.CakeIngredients.Count; ++i)
            {
                for (int j = 1; j < model.CakeIngredients.Count; ++j)
                {
                    if (model.CakeIngredients[i].IngredientId ==
                        model.CakeIngredients[j].IngredientId)
                    {
                        model.CakeIngredients[i].Count +=
                            model.CakeIngredients[j].Count;
                        model.CakeIngredients.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.CakeIngredients.Count; ++i)
            {
                source.CakeIngredients.Add(new CakeIngredient
                {
                    Id = ++maxPCId,
                    CakeId = maxId + 1,
                    IngredientId = model.CakeIngredients[i].IngredientId,
                    Count = model.CakeIngredients[i].Count
                });
            }
        }

        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.CakeIngredients.Count; ++i)
            {
                if (source.CakeIngredients[i].CakeId == id)
                {
                    source.CakeIngredients.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Cakes.Count; ++i)
            {
                if (source.Cakes[i].Id == id)
                {
                    source.Cakes.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Пироженое не найдено");
        }

        public CakeViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Cakes.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<CakeIngredientViewModel> cakeIngredients = new List<CakeIngredientViewModel>();
                for (int j = 0; j < source.CakeIngredients.Count; ++j)
                {
                    if (source.CakeIngredients[j].CakeId == source.Cakes[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.CakeIngredients[j].IngredientId == source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        cakeIngredients.Add(new CakeIngredientViewModel
                        {
                            Id = source.CakeIngredients[j].Id,
                            CakeId = source.CakeIngredients[j].CakeId,
                            IngredientId = source.CakeIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.CakeIngredients[j].Count
                        });
                    }
                }
                if (source.Cakes[i].Id == id)
                {
                    return new CakeViewModel
                    {
                        Id = source.Cakes[i].Id,
                        CakeName = source.Cakes[i].CakeName,
                        Price = source.Cakes[i].Price,
                        CakeIngredients = cakeIngredients
                    };
                }
            }

            throw new Exception("Пироженое не найдено");
        }

        public List<CakeViewModel> GetList()
        {
            List<CakeViewModel> result = new List<CakeViewModel>();
            for (int i = 0; i < source.Cakes.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<CakeIngredientViewModel> CakeIngredients = new List<CakeIngredientViewModel>();
                for (int j = 0; j < source.CakeIngredients.Count; ++j)
                {
                    if (source.CakeIngredients[j].CakeId == source.Cakes[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Cakes.Count; ++k)
                        {
                            if (source.CakeIngredients[j].IngredientId == source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        CakeIngredients.Add(new CakeIngredientViewModel
                        {
                            Id = source.CakeIngredients[j].Id,
                            CakeId = source.CakeIngredients[j].CakeId,
                            IngredientId = source.CakeIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.CakeIngredients[j].Count
                        });
                    }
                }
                result.Add(new CakeViewModel
                {
                    Id = source.Cakes[i].Id,
                    CakeName = source.Cakes[i].CakeName,
                    Price = source.Cakes[i].Price,
                    CakeIngredients = CakeIngredients
                });
            }
            return result;
        }

        public void UpdElement(CakeBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Cakes.Count; ++i)
            {
                if (source.Cakes[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Cakes[i].CakeName == model.CakeName &&
                    source.Cakes[i].Id != model.Id)
                {
                    throw new Exception("Уже есть пироженое с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Пироженое не найдено");
            }
            source.Cakes[index].CakeName = model.CakeName;
            source.Cakes[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.CakeIngredients.Count; ++i)
            {
                if (source.CakeIngredients[i].Id > maxPCId)
                {
                    maxPCId = source.CakeIngredients[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.CakeIngredients.Count; ++i)
            {
                if (source.CakeIngredients[i].CakeId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.CakeIngredients.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.CakeIngredients[i].Id == model.CakeIngredients[j].Id)
                        {
                            source.CakeIngredients[i].Count = model.CakeIngredients[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.CakeIngredients.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.CakeIngredients.Count; ++i)
            {
                if (model.CakeIngredients[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.CakeIngredients.Count; ++j)
                    {
                        if (source.CakeIngredients[j].CakeId == model.Id &&
                            source.CakeIngredients[j].IngredientId == model.CakeIngredients[i].IngredientId)
                        {
                            source.CakeIngredients[j].Count += model.CakeIngredients[i].Count;
                            model.CakeIngredients[i].Id = source.CakeIngredients[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.CakeIngredients[i].Id == 0)
                    {
                        source.CakeIngredients.Add(new CakeIngredient
                        {
                            Id = ++maxPCId,
                            CakeId = model.Id,
                            IngredientId = model.CakeIngredients[i].IngredientId,
                            Count = model.CakeIngredients[i].Count
                        });
                    }
                }
            }
        }
    }
}
