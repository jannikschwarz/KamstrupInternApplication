using System.Collections.Generic;
using System.Threading.Tasks;
using RestWebApi.Data.Model;

namespace RestWebApi.Db
{
    public interface IDbItemService
    {
        Task<List<Item>> getItemsAsync();
    }
}