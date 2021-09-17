using EmptyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Services.IRepositories
{
    public interface ICategoryRepo
    {
        IEnumerable<CategoryList> AllCategories();
    }
}
