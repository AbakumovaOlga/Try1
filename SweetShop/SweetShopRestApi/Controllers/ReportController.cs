using SweetShopService.BindingModels;
using SweetShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SweetShopRestApi.Controllers
{
    public class ReportController : ApiController
    {

        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetFridgesLoad()
        {
            var list = _service.GetFridgesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetCustomerRequests(ReportBindingModel model)
        {
            var list = _service.GetCustomerRequests(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void SaveCakePrice(ReportBindingModel model)
        {
            _service.SaveCakePrice(model);
        }

        [HttpPost]
        public void SaveFridgesLoad(ReportBindingModel model)
        {
            _service.SaveFridgesLoad(model);
        }

        [HttpPost]
        public void SaveCustomerRequests(ReportBindingModel model)
        {
            _service.SaveCustomerRequests(model);
        }
    }
}
