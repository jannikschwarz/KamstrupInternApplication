using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;

namespace Database.Db.Service
{
    public interface IDbOrderService
    {
        Task<string> getOrdersAsync();
        Task addOrderAsync(Order order);
    }
}