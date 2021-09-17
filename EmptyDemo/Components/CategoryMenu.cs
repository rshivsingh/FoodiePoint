using EmptyDemo.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Components
{
    public class CategoryMenu: ViewComponent
    {
        private ICategoryRepo _categoryrepo;

        public CategoryMenu(ICategoryRepo categoryRepo)
        {
            _categoryrepo = categoryRepo;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryrepo.AllCategories().OrderBy(x => x.CategoryName);
            return View(categories);
        }
    }
}
