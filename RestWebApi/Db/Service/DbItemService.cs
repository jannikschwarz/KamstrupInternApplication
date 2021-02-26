using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Database.Db.Context;
using Microsoft.EntityFrameworkCore;
using RestWebApi.Data.Model;

namespace RestWebApi.Db
{
    public class DbItemService: IDbItemService
    {
        private DatabaseContext ctx = new DatabaseContext();
        public async Task<List<Item>> getItemsAsync()
        {
            List<Item> items = await ctx.itemsDbSet.ToListAsync();
            return items;
        }
    }
}