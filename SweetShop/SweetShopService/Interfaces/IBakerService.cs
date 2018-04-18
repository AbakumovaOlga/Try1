using SweetShopService.BindingModels;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.Interfaces
{
    public interface IBakerService
    {
        List<BakerViewModel> GetList();

        BakerViewModel GetElement(int id);

        void AddElement(BakerBindingModel model);

        void UpdElement(BakerBindingModel model);

        void DelElement(int id);
    }
}
