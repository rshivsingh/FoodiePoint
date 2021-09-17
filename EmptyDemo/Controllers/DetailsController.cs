using EmptyDemo.Services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Controllers
{
    [Authorize]
    public class DetailsController : Controller
    {
        private readonly IItemsRepo _itemsRepo;
        public DetailsController(IItemsRepo itemsRepo)
        {
            _itemsRepo = itemsRepo;
        }
        public IActionResult Index(int ItemId)
        {
            var item = _itemsRepo.GetItemWithId(ItemId);
            return View(item);
        }
    }
}
