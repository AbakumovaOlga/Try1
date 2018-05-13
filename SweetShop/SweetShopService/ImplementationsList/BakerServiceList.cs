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
    public class BakerServiceList : IBakerService
    {
        private DataListSingleton source;

        public BakerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(BakerBindingModel model)
        {
            Baker element = source.Bakers.FirstOrDefault(rec => rec.BakerFIO == model.BakerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            int maxId = source.Bakers.Count > 0 ? source.Bakers.Max(rec => rec.Id) : 0;
            source.Bakers.Add(new Baker
            {
                Id = maxId + 1,
                BakerFIO = model.BakerFIO
            });
        }

        public void DelElement(int id)
        {
            Baker element = source.Bakers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Bakers.Remove(element);
            }
            else
            {
                throw new Exception("Пекарь не найден");
            }
        }

        public BakerViewModel GetElement(int id)
        {
            Baker element = source.Bakers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BakerViewModel
                {
                    Id = element.Id,
                    BakerFIO = element.BakerFIO
                };
            }
            throw new Exception("Пекарь не найден");
        }

        public List<BakerViewModel> GetList()
        {
            List<BakerViewModel> result = source.Bakers
                 .Select(rec => new BakerViewModel
                 {
                     Id = rec.Id,
                     BakerFIO = rec.BakerFIO
                 })
                 .ToList();
            return result;
        }

        public void UpdElement(BakerBindingModel model)
        {
            Baker element = source.Bakers.FirstOrDefault(rec =>
            rec.BakerFIO == model.BakerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = source.Bakers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Пекарь не найден");
            }
            element.BakerFIO = model.BakerFIO;
        }
    }
}
