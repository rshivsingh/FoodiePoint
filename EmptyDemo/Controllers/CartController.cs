using EmptyDemo.Models;
using EmptyDemo.Services.IRepositories;
using EmptyDemo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IItemsRepo _items;

        public CartController(IItemsRepo itemsRepo, ShoppingCart shoppingCart)
        {
            _items = itemsRepo;
            _shoppingCart = shoppingCart;
        }

        
        public IActionResult Index(int ItemId)
        {
            var items = _shoppingCart.GetShoppingItems().ToList();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotal()

            };

            return View(shoppingCartViewModel);
        }

        public IActionResult AddToCart(int ItemId)
        {
            var item = _items.GetItemWithId(ItemId);

            if(item != null)
            {
                _shoppingCart.AddToCart(item);
            }

            return RedirectToAction("Index");
            //return RedirectToAction("Index", "Home"); //Action, Controller
        }

        [Authorize]
        public IActionResult RemoveFromCart(int ItemId)
        {
            var item = _items.GetItemWithId(ItemId);

            if (item != null)
            {
                _shoppingCart.RemoveFromcart(item);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
