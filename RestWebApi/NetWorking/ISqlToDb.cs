using System;
using RestWebApi.Data.Model;

namespace RestWebApi.NetWorking
{
    public interface ISqlToDb
    {
        Object getItems();
        Object getOrders();
        void addOrder(Order order);
    }
}