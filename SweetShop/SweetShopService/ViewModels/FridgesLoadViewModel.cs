using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService.ViewModels
{
    public class FridgesLoadViewModel
    {
        public string FridgeName { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<Tuple<string, int>> Ingredients { get; set; }
    }
}