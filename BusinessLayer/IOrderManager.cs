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

        List<Order> GetCustomerOrders();

        List<Order> GetArchivedOrders();

        List<Order> GetOrders();

        Order GetOrder(int id);

        Order GetCustomerOrder(int id);

        Order AddOrder(Order order);

        int UpdateOrder(Order order);

        int SetDelivered(Order order);

        int DeleteOrder(int id);

    }
}