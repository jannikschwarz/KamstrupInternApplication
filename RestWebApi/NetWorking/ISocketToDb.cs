using System;
using RestWebApi.Data.Model;

namespace RestWebApi.NetWorking
{
    public interface ISocketToDb
    {
        Object getItems();
        Object getOrders();
        void addOrder(Order order);
    }
}