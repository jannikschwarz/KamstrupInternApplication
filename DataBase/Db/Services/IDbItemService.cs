using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataBase.Db
{
    public interface IDbItemService
    {
        Task<List<Item>> getItemsAsync();
    }
}