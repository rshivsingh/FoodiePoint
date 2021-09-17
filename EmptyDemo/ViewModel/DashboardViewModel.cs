using EmptyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.ViewModel
{
    public class DashboardViewModel
    {
        public IEnumerable<Item> Special { get; set; }
        public IEnumerable<Item> Discount { get; set; }
        public string srch { get; set; }
    }
}
