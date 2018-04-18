using SweetShopService.BindingModels;
//using SweetShopService.Interfaces;
using SweetShopService.ViewModels;
using SweetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetShopService.Interfaces;

namespace SweetShopService.ImplementationsList
{
    public class CustomerServiceList : ICustomerService
    {
        private DataListSingleton source;

        public CustomerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = source.Customers.Select(rec => new CustomerViewModel
            {
                Id = rec.Id,
                CustomerFIO = rec.CustomerFIO
            }).ToList();
            return result;


        }
        /* public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = (from cus in source.Customers 
                                             select new CustomerViewModel
                                             {
                                                 Id = cus.Id,
                                                 CustomerFIO = cus.CustomerFIO
                                             }).ToList();
            return result;
        }*/

        public CustomerViewModel GetElement(int id)
        {
            Customer element = source.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CustomerViewModel
                {
                    Id = element.Id,
                    CustomerFIO = element.CustomerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CustomerBindingModel model)
        {
            Customer element = source.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Customers.Count > 0 ? source.Customers.Max(rec => rec.Id) : 0;
            source.Customers.Add(new Customer

            {
                Id = maxId + 1,
                CustomerFIO = model.CustomerFIO
            });
        }

        public void UpdElement(CustomerBindingModel model)
        {
            Customer element = source.Customers.FirstOrDefault(rec =>
 rec.CustomerFIO == model.CustomerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Customers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            element.CustomerFIO = model.CustomerFIO;
        }

        public void DelElement(int id)
        {
            Customer element = source.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Customers.Remove(element);
            }
            else
            {
            }
            throw new Exception("Клиент не найден");
        }
    }
}
