using EmptyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.ViewModel
{
    public class CategoryViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public string Category { get; set; }
    }
}
