using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFrontEnd.Data;

namespace BlazorFrontEnd.Data
{
    public interface IItemService
    {
        Task<List<Item>> getAllItemsAsync();
    }
}