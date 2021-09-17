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
    public class FoodiePointController : Controller
    {
        private ICategoryRepo _categoryRepo;
        private IItemsRepo _itemsRepo;

        public FoodiePointController(ICategoryRepo categoryRepo, IItemsRepo itemsRepo)
        {
            _itemsRepo = itemsRepo;
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            var model = _categoryRepo.AllCategories();
            return View(model);
        }

        public IActionResult List()
        {
            var model = _itemsRepo.GetAllItems();
            return View(model);
        }

        public IActionResult ItemsWithinCategory(string category)
        {
            var model = new CategoryViewModel();
            model.Items = _itemsRepo.GetAllItemsWithinCategory(category);
            model.Category = category;
            return View(model);
        }
    }
}
