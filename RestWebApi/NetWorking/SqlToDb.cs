using System;
using System.Collections.Generic;
using System.Data;
using RestWebApi.Data.Model;
using System.Data.SqlClient;

namespace RestWebApi.NetWorking
{
    public class SqlToDb : ISqlToDb
    {
        private string connectionString = null;
        private SqlConnection cnn;
        private string sql = null;
        private SqlCommand command;
        private SqlDataReader dataReader;

        public SqlToDb()
        {
            connectionString =
                "Data Source=127.0.0.1,5432;Initial Catalog=postgres;User ID=postgres;Password=jack1261";
        }

        public object getItems()
        {
            List<Item> items = new List<Item>();
            cnn = new SqlConnection(connectionString);
            try
            {
                sql = "select * from Item;";
                command = new SqlCommand(sql, cnn);
                cnn.Open();
                Console.WriteLine("Connection is OPEN");
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Item newItem = new Item();
                    newItem.id = (int)dataReader.GetValue(0);
                    newItem.nameOfItem = (string) dataReader.GetValue(1);
                    newItem.description = (string) dataReader.GetValue(2);
                    newItem.imageName = (string) dataReader.GetValue(3);
                    newItem.cost = (int) dataReader.GetValue(4);
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();
                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Can not open connection !");
                return null;
            }
        }

        public object getOrders()
        {
            List<Order> orders = new List<Order>();
            cnn = new SqlConnection(connectionString);
            try
            {
                sql = "select * from Orders;";
                command = new SqlCommand(sql, cnn);
                cnn.Open();
                Console.WriteLine("Connection is OPEN");
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Order newOrder = new Order();
                    newOrder.orderId = (int) dataReader.GetValue(0);
                    newOrder.nameOfBuyer = (string) dataReader.GetValue(1);
                    newOrder.timeOfOrder = (string) dataReader.GetValue(2);
                    SqlCommand itemCommand =
                        new SqlCommand("select * from Item where item_Id='" + dataReader.GetValue(3) + "'", cnn);
                    SqlDataReader tempReader = itemCommand.ExecuteReader();
                    Item orderItem = new Item();
                    orderItem.id = (int)tempReader.GetValue(0);
                    orderItem.nameOfItem = (string) tempReader.GetValue(1);
                    orderItem.description = (string) tempReader.GetValue(2);
                    orderItem.imageName = (string) tempReader.GetValue(3);
                    orderItem.cost = (int) tempReader.GetValue(4);
                    newOrder.boughtItem = orderItem;
                    tempReader.Close();
                    itemCommand.Dispose();
                }
                dataReader.Close();
                command.Dispose();
                cnn.Close();
                return orders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Can not open connection !");
                return null;
            }
        }

        public void addOrder(Order order)
        {
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection is OPEN");
                sql = "insert into Item values (" + order.orderId + "," + order.nameOfBuyer + "," + order.timeOfOrder +
                      "," + order.boughtItem.id + ");";
                command = new SqlCommand(sql, cnn);
                dataReader = command.ExecuteReader();
                dataReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Can not open connection !");
            }
        }
    }
}