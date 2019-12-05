using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface IOrderManager
    {

        //IOrdersDB OrdersDb { get; }

        List<Order> GetOrders();

        Order GetOrder(int id);

        Order AddOrder(Order order);

        int UpdateOrder(Order order);

        int DeleteOrder(int id);

    }
}