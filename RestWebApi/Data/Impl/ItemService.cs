using System.Collections.Generic;
using System.Threading.Tasks;
using RestWebApi.Data.Model;
using RestWebApi.NetWorking;

namespace RestWebApi.Data.Impl
{
    public class ItemService : IItemsService
    {
        private ISocketToDb so;
        private List<Item> items;

        public ItemService()
        {
            so = new SocketToDb();
            items = new List<Item>();
        }
        
        public async Task<List<Item>> getItemsAsync()
        {
            items = (List<Item>) so.getItems();
            return items;
        }
    }
}