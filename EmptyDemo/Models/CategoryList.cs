using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Models
{
    public class CategoryList
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Item> CategoryItems { get; set; }
    }
}
