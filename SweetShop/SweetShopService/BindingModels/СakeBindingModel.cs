using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.BindingModels
{
    public class CakeBindingModel
    {
        public int Id { get; set; }

        public string CakeName { get; set; }

        public decimal Price { get; set; }

        public List<CakeIngredientBindingModel> CakeIngredients { get; set; }
    }
}
