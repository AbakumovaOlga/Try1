using SweetShopService.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ViewModels
{
    public class CakeViewModel
    {
        public int Id { get; set; }

        public string CakeName { get; set; }

        public decimal Price { get; set; }

        public List<CakeIngredientViewModel> CakeIngredients { get; set; }
    }
}
