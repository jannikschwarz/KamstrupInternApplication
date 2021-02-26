using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Database.Db.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Db.Service
{
    public class DbItemService: IDbItemService
    {
        private DatabaseContext ctx = new DatabaseContext();
        public async Task<string> getItemsAsync()
        {
            List<Item> items = await ctx.itemsDbSet.ToListAsync();
            return JsonSerializer.Serialize(items);
        }
    }
}