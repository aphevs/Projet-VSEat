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
        

        //Get all orders to make an archive of it

        public List<Order> GetArchivedOrders()
        {

            List<Order> lCurrentOrder = null;
            List<Order> lOrder = OrderDBObject.GetCustomerOrders();

            foreach (Order order in lOrder)
            {

                if (order.status.ToLower() != "not delivered")
                {
                    if (lCurrentOrder == null)
                        lCurrentOrder = new List<Order>();

                    lCurrentOrder.Add(order);

                }
            }
            return lCurrentOrder;
        }


        //Get all orders which are not designed as "delivered"
        public List<Order> GetCustomerOrders()
        {


            List<Order> lCurrentOrder = null;
            List<Order> lOrder = OrderDBObject.GetCustomerOrders();

            foreach (Order order in lOrder)
            {

                if (order.status.ToLower() != "delivered" && order.status.ToLower() != "cancelled")
                {
                    if (lCurrentOrder == null)
                        lCurrentOrder = new List<Order>();

                    lCurrentOrder.Add(order);

                }
            }
            return lCurrentOrder;
 
        }

        public List<Order> GetOrders()
        {
            return OrderDBObject.GetOrders();

        }

        public Order GetOrder(int id)
        {
            return OrderDBObject.GetOrder(id);
        }

        public Order GetCustomerOrder(int id)
        {

            return OrderDBObject.GetCustomerOrder(id);

        }

        public Order AddOrder(Order order)
        {
            return OrderDBObject.AddOrder(order);
        }

        public int UpdateOrder(Order order)
        {
            return OrderDBObject.UpdateOrder(order);
        }

        public int SetDelivered(Order order)
        {

            return OrderDBObject.SetDelivered(order);
        }



        public int DeleteOrder(int id)
        {
            return OrderDBObject.DeleteOrder(id);
        }



    }
}

