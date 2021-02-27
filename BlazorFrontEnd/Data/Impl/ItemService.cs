using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorFrontEnd.Data;

namespace BlazorFrontEnd.Data
{
    public class ItemService : IItemService
    {
        private readonly HttpClient client;
        private string uri = "http://177.10.10.11:5002/";

        public ItemService()
        {
            client = new HttpClient();
        }

        public  async Task<List<Item>> getAllItemsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "Items");
            string message = await stringAsync;
            List<Item> result = JsonSerializer.Deserialize<List<Item>>(message);
            return result;
        }
    }
}