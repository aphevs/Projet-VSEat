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
        //Archive
        //List<Order> GetArchivedOrdersWithIdCourier(int IdGiven);


        //List of orders
        //List<Order> GetCustomerOrdersWithIdCourier(int IdGiven);

        //TEST TEST TEST
        List<Order> GetCustomerOrders();


        //This method will put a new order in the DB
        int SetOrder(Dictionary<int, int> dishes, int idCity, int idCustomer, DateTime dat);


        List<Order> GetCustomerOrdersWithIdCourier();
        List<Order> GetArchivedOrdersWithIdCourier();
        List<Order> GetOrders();

        Order GetOrder(int id);


        Order GetCustomerOrder(int id);

        Order AddOrder(Order order);
        Order CreateOrder(Order order);

        int UpdateOrder(Order order);

        int SetDelivered(Order order);

        int DeleteOrder(int id);
        
    }
}