using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Database.Db.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Database.Db.Service
{
    public class DbOrderService : IDbOrderService
    {
        private DatabaseContext ctx = new DatabaseContext();
        public async Task<string> getOrdersAsync()
        {
            List<Order> orders = await ctx.ordersDbSet.ToListAsync();
            return JsonSerializer.Serialize(orders);
        }

        public async Task addOrderAsync(Order order)
        {
            try
            {
                Item withOrder = await ctx.itemsDbSet.FirstAsync(i => i.id == order.boughtItem.id);
                List<Order> orderTempList = await ctx.ordersDbSet.ToListAsync();
                order.orderId = orderTempList.Count + 1;
                order.boughtItem = withOrder;
                await ctx.ordersDbSet.AddAsync(order);
                await ctx.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }
        }
    }
}