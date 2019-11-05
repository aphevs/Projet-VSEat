using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IOrdersDB
    {
    
        IConfiguration Configuration { get; }

        List<Order> GetOrders();

        Order GetOrder(int id);

        Order AddOrder(Order order);

        int UpdateOrder(Order order);

        int DeleteOrder(int id);


    }
}
