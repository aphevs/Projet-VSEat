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
        List<Order> GetArchivedOrdersWithIdCourier(int IdGiven);

        //This method will put a new order in the DB
        int SetOrder(Dictionary<int, int> dishes, int idCity, int idCustomer, DateTime dat);

        Order GetOrder(int id);

        List<Order> GetMyOrdersWithIdCustomer(int id);

        Order GetCustomerOrder(int id);


        int SetDelivered(Order order);


        
    }
}