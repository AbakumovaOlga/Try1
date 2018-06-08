using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
