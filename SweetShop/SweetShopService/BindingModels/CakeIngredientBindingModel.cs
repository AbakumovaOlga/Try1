using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.BindingModels
{
    [DataContract]
    public class CakeIngredientBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CakeId { get; set; }

        [DataMember]
        public int IngredientId { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
