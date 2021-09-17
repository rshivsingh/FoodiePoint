using EmptyDemo.Models;
using EmptyDemo.Services.IRepositories;
using EmptyDemo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IItemsRepo _itemsRepo;
        private readonly FoodiePointDBContext _context;
        private readonly ShoppingCart _cart;
        public HomeController(SignInManager<IdentityUser> signInManager, 
            IItemsRepo itemsRepo, FoodiePointDBContext context, ShoppingCart cart)
        {
            _cart = cart;
            _itemsRepo = itemsRepo;
            _context = context;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            return Redirect("/Identity/Account/Login");
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel();
            model.Special = _itemsRepo.SpecialItems();
            model.Discount = _itemsRepo.Discounteditems();
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                _cart.ClearCart();
                return Redirect("/Identity/Account/Login");
            }
            return BadRequest("User not logged in.");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Search(DashboardViewModel search)
        {
            if (search.srch == null)
                return Redirect("/Home/Dashboard");
            var srch = search.srch.ToLower();
            var model = _context.Items.Where(x => x.ItemName.ToLower().Contains(srch)).ToList();
            return View(model);
        }

    }
}
