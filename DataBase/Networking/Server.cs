using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using DataBase.Db;
using Model;

namespace DataBase.Networking
{
    class Server
    {
        private string content;
        private IDbItemService itemService;
        private IDbOrderService orderService;

        public Server(IDbItemService itemService, IDbOrderService orderService)
        {
            this.itemService = itemService;
            this.orderService = orderService;
        }

        public async void start()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 2920);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                byte[] dataFromClient = new byte[1024];
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);

                switch (s)
                {
                    case "GetItems":
                    {
                        content = JsonSerializer.Serialize(await itemService.getItemsAsync());
                        break;
                    }
                    case "GetOrders":
                    {
                        content = JsonSerializer.Serialize(await orderService.getOrdersAsync());
                        break;
                    }
                    case "AddOrder":
                    {
                        byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data1ToClient,0,data1ToClient.Length);
                        byte[] orderFromClient = new byte[1024];
                        int orderRead = stream.Read(orderFromClient, 0, orderFromClient.Length);
                        string orderString = Encoding.ASCII.GetString(orderFromClient, 0, orderRead);
                        Order toAdd = JsonSerializer.Deserialize<Order>(orderString);
                        await orderService.addOrderAsync(toAdd);
                        content = "Order added: " + toAdd.nameOfBuyer;
                        break;
                    }
                }

                byte[] dataToClient = Encoding.ASCII.GetBytes(content);
                stream.Write(dataToClient,0,dataToClient.Length);
                client.Close();
            }
        }
    }
}