using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using RestWebApi.Data.Model;

namespace RestWebApi.NetWorking
{
    public class SocketToDb : ISocketToDb
    {
        public object getItems()
        {
            TcpClient client = new TcpClient("177.10.10.12", 2920);
            NetworkStream stream = client.GetStream();

            byte[] datToServer = Encoding.ASCII.GetBytes("GetItems");
            stream.Write(datToServer,0,datToServer.Length);

            byte[] dataFromServer = new byte[1024];
            int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
            string respone = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
            List<Item> request = JsonSerializer.Deserialize<List<Item>>(respone);
            
            stream.Close();
            client.Close();
            return request;
        }

        public object getOrders()
        {
            TcpClient client = new TcpClient("177.10.10.12", 2920);
            NetworkStream stream = client.GetStream();

            byte[] datToServer = Encoding.ASCII.GetBytes("GetOrders");
            stream.Write(datToServer,0,datToServer.Length);

            byte[] dataFromServer = new byte[1024];
            int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
            string respone = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
            List<Order> request = JsonSerializer.Deserialize<List<Order>>(respone);
            
            stream.Close();
            client.Close();
            return request;
        }

        public void addOrder(Order order)
        {
            TcpClient client = new TcpClient("177.10.10.12", 2920);
            NetworkStream stream = client.GetStream();

            byte[] dataToServer = Encoding.ASCII.GetBytes("AddOrder");
            stream.Write(dataToServer,0,dataToServer.Length);

            byte[] dataFromServer = new byte[1024];
            int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
            string respone = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
            if (respone.Equals("Received"))
            {
                dataToServer = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(order));
                stream.Write(dataToServer,0,dataToServer.Length);
            }
            stream.Close();
            client.Close();
        }
    }
}