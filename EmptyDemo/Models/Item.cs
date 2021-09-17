using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Contents { get; set; }
        public int Price { get; set; }
        public string ItemDescription { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public CategoryList categoryList { get; set; }
        public Boolean IsSpecial { get; set; }
        public Boolean IsVeg { get; set; }
        public Boolean IsDiscAvail { get; set; }
        public int DiscPer { get; set; }
    }
}
