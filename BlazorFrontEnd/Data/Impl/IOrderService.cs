using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorFrontEnd.Data;

namespace BlazorFrontEnd.Data
{
    public interface IOrderService
    {
        Task addOrderAsync(Item item, string name);

        Task<List<Order>> getAllOrdersAsync();
    }
}