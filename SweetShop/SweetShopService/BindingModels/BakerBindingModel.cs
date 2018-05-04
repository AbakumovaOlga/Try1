using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.BindingModels
{
    [DataContract]
    public class BakerBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string BakerFIO { get; set; }
    }
}
