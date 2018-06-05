using SweetShopService.BindingModels;
using SweetShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.Interfaces
{
    public interface IReportService
    {
        void SaveCakePrice(ReportBindingModel model);

        List<FridgesLoadViewModel> GetFridgesLoad();

        void SaveFridgesLoad(ReportBindingModel model);

        List<CustomerRequestsModel> GetCustomerRequests(ReportBindingModel model);

        void SaveCustomerRequests(ReportBindingModel model);
    }
}