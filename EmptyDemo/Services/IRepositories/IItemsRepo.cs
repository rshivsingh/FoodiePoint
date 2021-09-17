using EmptyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyDemo.Services.IRepositories
{
    public interface IItemsRepo
    {
        IEnumerable<Item> GetAllItemsWithinCategory(string category);
        IEnumerable<Item> GetAllItems();

        IEnumerable<Item> SpecialItems();
        IEnumerable<Item> Discounteditems();
        Item GetItemWithId(int id);
    }
}
