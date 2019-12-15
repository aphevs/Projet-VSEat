using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IOrdersDB
    {
        List<Order> GetOrders();


        Order GetOrder(int id);
        List<Order> GetCustomerOrdersWithIdCourier(int IdGiven);

        void SetOrder(Dictionary<int, int> dishes, int idCustomer, DateTime date, int idCourier);




        int CountCourierOrders(DateTime date, int idCourier);

        Order GetCustomerOrder(int id);

       



        Order CreateOrder(Order order);
        Order AddOrder(Order order);

        int UpdateOrder(Order order);
        int SetDelivered(Order order);
        int DeleteOrder(int id);
       
    }
}
