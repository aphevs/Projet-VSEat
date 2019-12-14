using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IOrdersDB
    {
    
        //IConfiguration Configuration { get; }

        List<Order> GetOrders();

        //TEST TEST TEST
        List<Order> GetCustomerOrders();

        Order GetOrder(int id);
        Order GetCustomerOrder(int id);

        Order CreateOrder(Order order);
        Order AddOrder(Order order);

        int UpdateOrder(Order order);
        int SetDelivered(Order order);
        int DeleteOrder(int id);


        //List<Order> GetCustomerOrdersWithIdCourier(int IdGiven);



    }
}
