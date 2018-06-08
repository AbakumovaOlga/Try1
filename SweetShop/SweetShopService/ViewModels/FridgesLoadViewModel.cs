using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ViewModels
{
    [DataContract]
    public class FridgesLoadViewModel
    {
        [DataMember]
        public string FridgeName { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public List<FridgesIngredientLoadViewModel> Ingredients { get; set; }
    }

    [DataContract]
    public class FridgesIngredientLoadViewModel
    {
        [DataMember]
        public string IngredientName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}