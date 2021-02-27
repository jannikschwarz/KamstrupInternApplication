using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorFrontEnd.Data;

namespace BlazorFrontEnd.Data
{
    public class OrderService: IOrderService
    {
        private HttpClient client;
        private string uri = "http://177.10.10.11:5002";

        public OrderService()
        {
            client = new HttpClient();
        }
        
        public async Task addOrderAsync(Item item, string name)
        {
            if (item == null || name.Equals(""))
            {
                Console.WriteLine("Empty string or item");
            }
            else
            {
                Order order = new Order(name, item);
                order.orderId = 0;
                string orderToSend = JsonSerializer.Serialize(order);
                HttpContent content = new StringContent(orderToSend, Encoding.UTF8, "application/json");
                await client.PostAsync(uri + "/Orders", content);
            }
        }

        public async Task<List<Order>> getAllOrdersAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Orders");
            string message = await stringAsync;
            List<Order> result = JsonSerializer.Deserialize<List<Order>>(message);
            return result;
        }
    }
}