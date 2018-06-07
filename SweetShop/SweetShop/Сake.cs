using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Cake
    {
        public int Id { get; set; }

        [Required]
        public string CakeName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("CakeId")]
        public virtual List<CakeIngredient> CakeIngredients { get; set; }
    }
}
