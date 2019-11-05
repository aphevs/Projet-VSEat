using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class OrderManager
    {
        public IOrdersDB OrderDB { get; }


        public OrderManager(IConfiguration configuration)
        {
           OrderDB = new OrdersDB(configuration);

        }

        public List<Order> GetOrders()
        {
            return OrderDB.GetOrders();

        }

        public Order GetOrder(int id)
        {
            return OrderDB.GetOrder(id);
        }

        public Order AddOrder(Order order)
        {
            return OrderDB.AddOrder(order);
        }

        public int UpdateOrder(Order order)
        {
            return OrderDB.UpdateOrder(order);
        }

        public int DeleteOrder(int id)
        {
            return OrderDB.DeleteOrder(id);
        }



    }
}

