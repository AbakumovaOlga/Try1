using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop
{
    public class Baker
    {
        public int Id { get; set; }

        [Required]
        public string BakerFIO { get; set; }

        [ForeignKey("BakerId")]
        public virtual List<Request> Requests { get; set; }
    }
}
