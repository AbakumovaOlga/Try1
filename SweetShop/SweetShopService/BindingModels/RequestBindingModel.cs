using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.BindingModels
{
    public class RequestBindingModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CakeId { get; set; }

        public int? BakerId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
