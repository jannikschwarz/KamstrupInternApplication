using System.Collections.Generic;
using System.Threading.Tasks;
using RestWebApi.Data.Model;

namespace RestWebApi.Data.Impl
{
    public interface IItemsService
    {
        Task<List<Item>> getItemsAsync();
    }
}