using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database.Db.Service;
using Database.Model;

namespace Database.Networking
{
    public class SocketServer
    {
        private string content;
        private IDbItemService itemService;
        private IDbOrderService orderService;

        public SocketServer(IDbItemService itemService, IDbOrderService orderService)
        {
            this.itemService = itemService;
            this.orderService = orderService;
        }
        
        public async void start()
        {
            Console.WriteLine(itemService.getItemsAsync());
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 2920);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();
                byte[] dataFromClient = new byte[4096];
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                string messageFromClient = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                content = null;

                switch (messageFromClient)
                {
                    case "GetItems":
                    {
                        content = await itemService.getItemsAsync();
                        break;
                    }
                    case "GetOrders":
                    {
                        content = await orderService.getOrdersAsync();
                        break;
                    }
                    case "AddOrder":
                    {
                        byte[] dataToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(dataToClient,0,dataToClient.Length);
                        byte[] objectFromClient = new byte[4096];
                        int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
                        string objectAsString = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
                        Order toAdd = JsonSerializer.Deserialize<Order>(objectAsString);
                        await orderService.addOrderAsync(toAdd);
                        break;
                    }
                }

                if (content != null)
                {
                    byte[] lastMessage = Encoding.ASCII.GetBytes(content);
                    stream.Write(lastMessage,0,lastMessage.Length);
                }
                
                client.Close();
            }
        }
    }
}