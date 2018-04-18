using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.BindingModels
{
    public class CakeIngredientBindingModel
    {
        public int Id { get; set; }

        public int CakeId { get; set; }

        public int IngredientId { get; set; }

        public int Count { get; set; }
    }
}
