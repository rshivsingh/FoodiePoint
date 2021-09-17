using EmptyDemo.Models;
using EmptyDemo.Services.IRepositories;
using EmptyDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Components
{
    public class ContentCount: ViewComponent
    {
        private readonly ShoppingCart _cart;

        public ContentCount(ShoppingCart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cart.GetShoppingItems().ToList();
            var cnt = 0;
            foreach(var item in items)
            {
                cnt += item.Quantity;
            }
            return View(new ShoppingCartViewModel { ShoppingCartTotal = cnt });
        }
    }
}
