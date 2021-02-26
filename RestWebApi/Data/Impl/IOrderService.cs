using System.Collections.Generic;
using System.Threading.Tasks;
using RestWebApi.Data.Model;

namespace RestWebApi.Data.Impl
{
    public interface IOrderService
    {
        Task<List<Order>> getOrdersAsync();
        Task orderAsync(Order order);
    }
}