using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ViewModels
{
    public class FridgeViewModel
    {
        public int Id { get; set; }

        public string FridgeName { get; set; }

        public List<FridgeIngredientViewModel> FridgeIngredients { get; set; }
    }
}
