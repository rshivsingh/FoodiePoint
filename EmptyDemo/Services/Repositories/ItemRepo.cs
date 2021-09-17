using EmptyDemo.Models;
using EmptyDemo.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Services.Repositories
{
    public class ItemRepo : IItemsRepo
    {
        List<Item> _items;
        private FoodiePointDBContext _context;

        public ItemRepo(FoodiePointDBContext context)
        {
            _context = context;
/*
            _items = new List<Item>
            {
                        new Item
                        {
                            ItemId=1,
                            categoryList = new CategoryList{ CategoryId=101, CategoryName="Dessert"},
                            ItemName="Apple Pie" ,
                            Contents=new List<string>{"abc", "xyz"},
                            Price= 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=2,
                            categoryList = new CategoryList{ CategoryId=101, CategoryName="Dessert"},
                            ItemName="Almond Malai Kulfi" ,
                            Contents=new List<string>{"abc", "xyz"},
                            Price= 150,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=3,
                            categoryList = new CategoryList{ CategoryId=101, CategoryName="Dessert"},
                            ItemName="Lemon Tart" ,
                            Contents=new List<string>{"abc", "xyz"},
                            Price= 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=4,
                            categoryList = new CategoryList{ CategoryId=102, CategoryName="Pizza"},
                            ItemName="Neapolitan Pizza" ,
                            Contents=new List<string>{"abc", "xyz"},
                            Price= 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=5,
                            categoryList = new CategoryList{ CategoryId=102, CategoryName="Pizza"},
                            ItemName="Sicilian Pizza" ,
                            Contents=new List<string>{"abc", "xyz"},
                            Price= 150,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=6,
                            ItemName="Detroit Pizza" ,
                            categoryList = new CategoryList{ CategoryId=102, CategoryName="Pizza"},
                            Contents=new List<string>{"abc", "xyz"},
                            Price= 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=7,
                            ItemName="Ben & Jerry's Chocolate Brownie Fudge" ,
                            categoryList = new CategoryList{ CategoryId=103, CategoryName="Ice Cream"},
                            Contents=new List<string>{"abc", "xyz"},
                            Price= 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=8,
                            ItemName="Häagen-Dazs Vanilla" ,
                            Contents=new List<string>{"abc", "xyz"},
                            categoryList = new CategoryList{ CategoryId=103, CategoryName="Ice Cream"},
                            Price= 150,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId=9,
                            ItemName="Dove Mint Chocolate Chip Ice Cream" ,
                            Contents=new List<string>{"abc", "xyz"},
                            categoryList = new CategoryList{ CategoryId=103, CategoryName="Ice Cream"},
                            Price= 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        }
            };*/
        }

        public IEnumerable<Item> Discounteditems()
        {
            return _context.Items.Where(x => x.IsDiscAvail == true);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.OrderBy(x => x.ItemName);
        }

        public IEnumerable<Item> GetAllItemsWithinCategory(string category)
        {
            var id = _context.Categories.Where(x => x.CategoryName == category).Select(x => x.CategoryId).FirstOrDefault();
            var val = _context.Items.Where(x => x.CategoryId==id);
            return val.OrderBy(x => x.ItemName);
        }

        public Item GetItemWithId(int id)
        {
            return _context.Items.FirstOrDefault(x=> x.ItemId==id);
        }

        public IEnumerable<Item> SpecialItems()
        {
            return _context.Items.Where(x => x.IsSpecial == true);
        }
    }
}
