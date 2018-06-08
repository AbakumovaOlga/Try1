using SweetShopService.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ViewModels
{
    [DataContract]
    public class CakeViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CakeName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<CakeIngredientViewModel> CakeIngredients { get; set; }
    }
}
