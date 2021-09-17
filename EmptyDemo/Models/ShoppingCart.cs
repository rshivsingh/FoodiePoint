using EmptyDemo.Services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Models
{
    public class ShoppingCart
    {
        private readonly FoodiePointDBContext _context;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(FoodiePointDBContext foodiePointDBContext)
        {
            _context = foodiePointDBContext;
        }

        //GetCart/AddtoCart/RemoveFromcart/GetShoppingitems/clear cart/gettotal

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<FoodiePointDBContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        public void AddToCart(Item item)
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.SingleOrDefault(
                    s => s.Item.ItemId == item.ItemId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Item = item,
                    Quantity = 1,
                    ItemRef=item.ItemId
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public void RemoveFromcart(Item item)
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.SingleOrDefault(
                    s => s.Item.ItemId == item.ItemId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }                
            }
            _context.SaveChanges();
        }

        public IEnumerable<ShoppingCartItem> GetShoppingItems()
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.Where(
                    s => s.ShoppingCartId == ShoppingCartId);

            return shoppingCartItem;
        }

        public void ClearCart()
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.Where(
                    s => s.ShoppingCartId == ShoppingCartId);

            foreach(var item in shoppingCartItem)
            {
                var itemdel = _context.Items.Where(s => s.ItemId == item.ItemRef);
                _context.ShoppingCartItems.Remove(item);
            }
            _context.SaveChanges();
        }

        public double GetTotal()
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.Where(
                    s => s.ShoppingCartId == ShoppingCartId);
            double total = 0;
            foreach (var itemnew in shoppingCartItem)
            {
                var val = _context.Items.Where(x => x.ItemId == itemnew.ItemRef).ToList();
                foreach(var item in val)
                    total = total + (itemnew.Quantity * item.Price) - ((item.DiscPer / 100.0) * item.Price* itemnew.Quantity);
            }
            return total;
        }

    }
}
