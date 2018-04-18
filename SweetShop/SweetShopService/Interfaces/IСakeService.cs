using SweetShopService.BindingModels;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.Interfaces
{
    public interface ICakeService
    {
        List<CakeViewModel> GetList();

        CakeViewModel GetElement(int id);

        void AddElement(CakeBindingModel model);

        void UpdElement(CakeBindingModel model);

        void DelElement(int id);
    }
}
