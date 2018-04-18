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
            int maxId = 0;
            for (int i = 0; i < source.Bakers.Count; ++i)
            {
                if (source.Bakers[i].Id > maxId)
                {
                    maxId = source.Bakers[i].Id;
                }
                if (source.Bakers[i].BakerFIO == model.BakerFIO)
                {
                    throw new Exception("Уже есть пекарь с таким ФИО");
                }
            }
            source.Bakers.Add(new Baker
            {
                Id = maxId + 1,
                BakerFIO = model.BakerFIO
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Bakers.Count; ++i)
            {
                if (source.Bakers[i].Id == id)
                {
                    source.Bakers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Пекарь не найден");
        }

        public BakerViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Bakers.Count; ++i)
            {
                if (source.Bakers[i].Id == id)
                {
                    return new BakerViewModel
                    {
                        Id = source.Bakers[i].Id,
                        BakerFIO = source.Bakers[i].BakerFIO
                    };
                }
            }
            throw new Exception("Пекарь не найден");
        }

        public List<BakerViewModel> GetList()
        {
            List<BakerViewModel> result = new List<BakerViewModel>();
            for (int i = 0; i < source.Bakers.Count; ++i)
            {
                result.Add(new BakerViewModel
                {
                    Id = source.Bakers[i].Id,
                    BakerFIO = source.Bakers[i].BakerFIO
                });
            }
            return result;
        }

        public void UpdElement(BakerBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Bakers.Count; ++i)
            {
                if (source.Bakers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Bakers[i].BakerFIO == model.BakerFIO &&
                    source.Bakers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть пекарь с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Пекарь не найден");
            }
            source.Bakers[index].BakerFIO = model.BakerFIO;
        }
    }
}
