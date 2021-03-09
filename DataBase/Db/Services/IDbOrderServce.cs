using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataBase.Db
{
    public interface IDbOrderService
    {
        Task<List<Order>> getOrdersAsync();
        Task addOrderAsync(Order order);
    }
}