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
    public class BakerServiceBD : IBakerService
    {
        private AbstractDbContext context;

        public BakerServiceBD(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<BakerViewModel> GetList()
        {
            List<BakerViewModel> result = context.Bakers
                .Select(rec => new BakerViewModel
                {
                    Id = rec.Id,
                    BakerFIO = rec.BakerFIO
                })
                .ToList();
            return result;
        }

        public BakerViewModel GetElement(int id)
        {
            Baker element = context.Bakers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BakerViewModel
                {
                    Id = element.Id,
                    BakerFIO = element.BakerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(BakerBindingModel model)
        {
            Baker element = context.Bakers.FirstOrDefault(rec => rec.BakerFIO == model.BakerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Bakers.Add(new Baker
            {
                BakerFIO = model.BakerFIO
            });
            context.SaveChanges();
        }

        public void UpdElement(BakerBindingModel model)
        {
            Baker element = context.Bakers.FirstOrDefault(rec =>
rec.BakerFIO == model.BakerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = context.Bakers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BakerFIO = model.BakerFIO;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Baker element = context.Bakers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Bakers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
