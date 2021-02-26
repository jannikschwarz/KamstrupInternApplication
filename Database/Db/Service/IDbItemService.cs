using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;

namespace Database.Db.Service
{
    public interface IDbItemService
    {
        Task<string> getItemsAsync();
    }
}