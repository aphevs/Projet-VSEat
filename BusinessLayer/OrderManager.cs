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
        private ICouriersDB CourierDBObject { get; }

        public OrderManager(IOrdersDB orderDB, ICouriersDB couriersDB)
        {
            OrderDBObject = orderDB;

            CourierDBObject = couriersDB;
        }


        //This method will put a new order in the DB
        public int SetOrder(Dictionary<int, int> dishes, int idCity, int idCourier, DateTime date)
        {
            // Get couriers near restaurant
            List<Courier> couriers = new List<Courier>();
            couriers = CourierDBObject.GetCouriersOfACity(idCity);

            // Get last available courier of the list
            Courier courierAvailable = null;
            foreach (Courier courier in couriers)
            {
                if (OrderDBObject.CountCourierOrders(date, idCourier) < 5)
                    courierAvailable = courier;
            }

            // Put the order into BD (in Order_dish)
            if (courierAvailable != null)
            {
                OrderDBObject.SetOrder(dishes, idCourier, date, courierAvailable.IdCourier);
                return 1;
            }
            return 0;
        }







        //Get all orders which are not designed as "delivered"
        public List<Order> GetCustomerOrdersWithIdCourier()
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

        //Get all orders to make an archive of it

        public List<Order> GetArchivedOrdersWithIdCourier()
        {

            List<Order> lCurrentOrder = null;
            List<Order> lOrder = OrderDBObject.GetCustomerOrders();

            foreach (Order order in lOrder)
            {

                if (order.status.ToLower() == "delivered" || order.status.ToLower() == "cancelled" )
                {
                    if (lCurrentOrder == null)
                        lCurrentOrder = new List<Order>();

                    lCurrentOrder.Add(order);

                }
            }
            return lCurrentOrder;
        }





        public List<Order> GetCustomerOrders()
        {
            return OrderDBObject.GetCustomerOrders();
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

        public Order CreateOrder(Order order)
        {

            return OrderDBObject.CreateOrder(order);
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

