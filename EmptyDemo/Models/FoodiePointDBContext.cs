using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Models
{
    public class FoodiePointDBContext : DbContext
    {
        public FoodiePointDBContext(DbContextOptions<FoodiePointDBContext> options) : base(options)
        {

        }

        public DbSet<CategoryList> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryList>().HasData(
                new CategoryList { CategoryId = 1, CategoryName = "Dessert" },
                new CategoryList { CategoryId = 2, CategoryName = "Ice Cream" },
                new CategoryList { CategoryId = 3, CategoryName = "Pizza" });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemId = 1,
                    ItemName = "Apple Pie",
                    CategoryId = 1,
                    Contents = "abc, xyz",
                    IsSpecial=true,
                    IsVeg=true,
                    IsDiscAvail=false,
                    DiscPer=0,
                    Price = 200,
                    ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                },
                        new Item
                        {
                            ItemId = 2,
                            ItemName = "Almond Malai Kulfi",
                            CategoryId = 1,
                            IsSpecial = true,
                            IsVeg = true,
                            IsDiscAvail = false,
                            DiscPer = 0,
                            Contents = "abc, xyz",
                            Price = 150,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId = 3,
                            ItemName = "Lemon Tart",
                            CategoryId = 1,
                            IsSpecial = false,
                            IsVeg = true,
                            IsDiscAvail = true,
                            DiscPer = 5,
                            Contents = "abc, xyz",
                            Price = 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId = 4,
                            ItemName = "Neapolitan Pizza",
                            CategoryId = 3,
                            IsSpecial = true,
                            IsVeg = true,
                            IsDiscAvail = true,
                            DiscPer = 8,
                            Contents = "abc, xyz",
                            Price = 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId = 5,
                            ItemName = "abc, xyz",
                            CategoryId = 3,
                            IsSpecial = false,
                            IsVeg = true,
                            IsDiscAvail = false,
                            DiscPer = 0,
                            Contents = "abc, xyz",
                            Price = 150,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId = 6,
                            ItemName = "Detroit Pizza",
                            CategoryId = 3,
                            IsSpecial = true,
                            IsVeg = false,
                            IsDiscAvail = false,
                            DiscPer = 0,
                            Contents = "abc, xyz",
                            Price = 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId = 7,
                            ItemName = "Ben & Jerry's Chocolate Brownie Fudge",
                            CategoryId = 2,
                            IsSpecial = true,
                            IsVeg = true,
                            IsDiscAvail = false,
                            DiscPer = 0,
                            Contents = "abc, xyz",
                            Price = 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId = 8,
                            ItemName = "Häagen-Dazs Vanilla",
                            CategoryId = 2,
                            IsSpecial = true,
                            IsVeg = true,
                            IsDiscAvail = true,
                            DiscPer = 4,
                            Contents = "abc, xyz",
                            Price = 150,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        },
                        new Item
                        {
                            ItemId = 9,
                            ItemName = "Dove Mint Chocolate Chip Ice Cream",
                            Contents = "abc, xyz",
                            CategoryId = 2,
                            IsSpecial = false,
                            IsVeg = true,
                            IsDiscAvail = true,
                            DiscPer = 10,
                            Price = 200,
                            ItemDescription = "Classic for a get-together and you might not have any leftovers to bring home.",
                        });
        }
    }
}
