using System.Collections.Generic;
using System.Threading.Tasks;
using RestWebApi.Data.Model;
using RestWebApi.NetWorking;

namespace RestWebApi.Data.Impl
{
    public class OrderService : IOrderService
    {
        private ISocketToDb so;
        private List<Order> orders;

        public OrderService()
        {
            so = new SocketToDb();
            orders = new List<Order>();
        }
        
        public async Task<List<Order>> getOrdersAsync()
        {
            orders = (List<Order>) so.getOrders();
            return orders;
        }

        public async Task orderAsync(Order order)
        {
            so.addOrder(order);
        }
    }
}