using EmptyDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly FoodiePointDBContext _context;
        private readonly ShoppingCart _cart;
        public OrderController(FoodiePointDBContext context, ShoppingCart cart)
        {
            _cart = cart;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                _cart.ClearCart();
                return RedirectToAction("TransComplete");
            }
            return View();
        }

        public IActionResult TransComplete()
        {
            return View();
        }
    }
}
