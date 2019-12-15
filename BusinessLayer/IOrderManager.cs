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

        //List of orders
        List<Order> GetCustomerOrdersWithIdCourier(int IdGiven);

        //Archive
        List<Order> GetArchivedOrdersWithCourier(int IdGiven);

        //This method will put a new order in the DB
        int SetOrder(Dictionary<int, int> dishes, int idCity, int idCustomer, DateTime dat);


        List<Order> GetMyOrdersWithIdCustomer(int IdGiven);




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