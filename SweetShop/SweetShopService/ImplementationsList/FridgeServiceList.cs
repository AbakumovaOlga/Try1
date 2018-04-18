using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetShopService.BindingModels;
using SweetShopService.ViewModels;
using SweetShopService.Interfaces;
using SweetShop;

namespace SweetShopService.ImplementationsList
{
    public class FridgeServiceList : IFridgeService
    {
        private DataListSingleton source;

        public void AddElement(FridgeBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Fridges.Count; ++i)
            {
                if (source.Fridges[i].Id > maxId)
                {
                    maxId = source.Fridges[i].Id;
                }
                if (source.Fridges[i].FridgeName == model.FridgeName)
                {
                    throw new Exception("Уже есть холодильник с таким названием");
                }
            }
            source.Fridges.Add(new Fridge
            {
                Id = maxId + 1,
                FridgeName = model.FridgeName
            });
        }

        public void DelElement(int id)
        {
            Fridge element = source.Fridges.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.FridgeIngredients.RemoveAll(rec => rec.FridgeId == id);
                source.Fridges.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }

        }

        public FridgeViewModel GetElement(int id)
        {
            Fridge element = source.Fridges.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new FridgeViewModel
                {
                    Id = element.Id,
                    FridgeName = element.FridgeName,
                    FridgeIngredients = source.FridgeIngredients
                            .Where(recPC => recPC.FridgeId == element.Id)
                             .Select(recPC => new FridgeIngredientViewModel
                             {
                                 Id = recPC.Id,
                                 FridgeId = recPC.FridgeId,
                                 IngredientId = recPC.IngredientId,
                                 IngredientName = source.Ingredients
                                     .FirstOrDefault(recC => recC.Id == recPC.IngredientId)?.IngredientName,
                                 Count = recPC.Count
                             })
                             .ToList()
                };
            }
            throw new Exception("Холодильник не найден");
        }

        public List<FridgeViewModel> GetList()
        {
            List<FridgeViewModel> result = source.Fridges
                .Select(rec => new FridgeViewModel
                {
                    Id = rec.Id,
                    FridgeName = rec.FridgeName,
                    FridgeIngredients = source.FridgeIngredients
                             .Where(recPC => recPC.FridgeId == rec.Id)
                             .Select(recPC => new FridgeIngredientViewModel
                             {

                                 Id = recPC.Id,
                                 FridgeId = recPC.FridgeId,
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

        public FridgeServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void UpdElement(FridgeBindingModel model)
        {
            Fridge element = source.Fridges.FirstOrDefault(rec =>
 rec.FridgeName == model.FridgeName && rec.Id != model.Id);
            if (element != null)
            {

                throw new Exception("Уже есть холодильник с таким названием");

            }
            element = source.Fridges.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Холодильник не найден");
            }
            element.FridgeName = model.FridgeName;
        }
    }
}
