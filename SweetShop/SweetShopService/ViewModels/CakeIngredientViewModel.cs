using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ViewModels
{
    [DataContract]
    public class CakeIngredientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CakeId { get; set; }

        [DataMember]
        public int IngredientId { get; set; }

        [DataMember]
        public string IngredientName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
