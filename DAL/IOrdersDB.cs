using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IOrdersDB
    {
        Order GetOrder(int id);
        List<Order> GetCustomerOrdersWithIdCourier(int IdGiven);
        void SetOrder(Dictionary<int, int> dishes, int idCustomer, DateTime date, int idCourier);
        int CountCourierOrders(DateTime date, int idCourier);
        Order GetCustomerOrder(int id);
        List<Order> GetMyOrdersWithIdCustomer(int IdGiven);
        int SetDelivered(Order order);

       
    }
}
