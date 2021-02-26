using System.Collections.Generic;
using System.Threading.Tasks;
using RestWebApi.Data.Model;


namespace RestWebApi.Db
{
    public interface IDbOrderService
    {
        Task<List<Order>> getOrdersAsync();
        Task addOrderAsync(Order order);
    }
}