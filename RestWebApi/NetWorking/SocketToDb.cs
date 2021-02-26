using System;
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
            TcpClient client = new TcpClient("127.0.0.1", 2920);
            NetworkStream stream = client.GetStream();
            
            byte[] dataToServer = Encoding.ASCII.GetBytes("GetItems");
            stream.Write(dataToServer,0,dataToServer.Length);
            
            byte[] dataFromServer = new byte[4096];
            int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
            string respone = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
            List<Item> request = JsonSerializer.Deserialize<List<Item>>(respone);
            stream.Close();
            client.Close();
            return request;
        }

        public object getOrders()
        {
            TcpClient client = new TcpClient("127.0.0.1", 2920);
            NetworkStream stream = client.GetStream();

            byte[] dataToServer = Encoding.ASCII.GetBytes("GetOrders");
            stream.Write(dataToServer,0,dataToServer.Length);
            
            byte[] dataFromServer = new byte[4096];
            int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
            string respone = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
            List<Order> request = JsonSerializer.Deserialize<List<Order>>(respone);
            
            stream.Close();
            client.Close();
            return request;
        }

        public void addOrder(Order order)
        {
            TcpClient client = new TcpClient("127.0.0.1", 2920);
            NetworkStream stream = client.GetStream();

            byte[] dataToServer = Encoding.ASCII.GetBytes("AddOrder");
            stream.Write(dataToServer,0,dataToServer.Length);

            byte[] messageRecieved = new byte[4096];
            int messageRead = stream.Read(messageRecieved, 0, messageRecieved.Length);

            string orderSerialized = JsonSerializer.Serialize(order);
            byte[] orderToServer = Encoding.ASCII.GetBytes(orderSerialized);
            stream.Write(orderToServer,0,orderToServer.Length);
            
            stream.Close();
            client.Close();
        }
    }
}