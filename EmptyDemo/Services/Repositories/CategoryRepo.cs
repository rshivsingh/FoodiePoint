using EmptyDemo.Models;
using EmptyDemo.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Services.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private FoodiePointDBContext _context;

        public CategoryRepo(FoodiePointDBContext context)
        {
            _context = context;
        }
        public IEnumerable<CategoryList> AllCategories()
        {
            return _context.Categories.OrderBy(x => x.CategoryName);
        }
    }
}
