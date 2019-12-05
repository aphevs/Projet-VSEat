using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class OrderManager : IOrderManager
    {
        private IOrdersDB OrderDBObject { get; }


        public OrderManager(IOrdersDB orderDB)
        {
            OrderDBObject = orderDB;

        }

        public List<Order> GetOrders()
        {
            return OrderDBObject.GetOrders();

        }

        public Order GetOrder(int id)
        {
            return OrderDBObject.GetOrder(id);
        }

        public Order AddOrder(Order order)
        {
            return OrderDBObject.AddOrder(order);
        }

        public int UpdateOrder(Order order)
        {
            return OrderDBObject.UpdateOrder(order);
        }

        public int DeleteOrder(int id)
        {
            return OrderDBObject.DeleteOrder(id);
        }



    }
}

