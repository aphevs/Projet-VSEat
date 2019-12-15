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
        public List<Order> GetMyOrdersWithIdCustomer(int id)
        {
            List<Order> lCurrentOrder = null;
            List<Order> lOrder = OrderDBObject.GetMyOrdersWithIdCustomer(id);

            foreach (Order order in lOrder)
            {

                if (order.status.ToLower() == "non delivered")
                {
                    if (lCurrentOrder == null)
                        lCurrentOrder = new List<Order>();

                    lCurrentOrder.Add(order);

                }
            }
            return lCurrentOrder;

        }



        //Get all orders which are designed as "delivered"
        public List<Order> GetCustomerOrdersWithIdCourier(int id)
        {
            List<Order> lCurrentOrder = null;
            List<Order> lOrder = OrderDBObject.GetCustomerOrdersWithIdCourier(id);

            foreach (Order order in lOrder)
            {

                if (order.status.ToLower() == "non delivered")
                {
                    if (lCurrentOrder == null)
                        lCurrentOrder = new List<Order>();

                    lCurrentOrder.Add(order);

                }
            }
            return lCurrentOrder;

        }

        //Get all orders which are designed as "delivered"
        public List<Order> GetArchivedOrdersWithIdCourier(int id)
        {
            List<Order> lCurrentOrder = null;
            List<Order> lOrder = OrderDBObject.GetCustomerOrdersWithIdCourier(id);

            foreach (Order order in lOrder)
            {

                if (order.status.ToLower() != "non delivered")
                {
                    if (lCurrentOrder == null)
                        lCurrentOrder = new List<Order>();

                    lCurrentOrder.Add(order);

                }
            }
            return lCurrentOrder;

        }

        public Order GetOrder(int id)
        {
            return OrderDBObject.GetOrder(id);
        }

        public int SetDelivered(Order order)
        {

            return OrderDBObject.SetDelivered(order);
        }



        public Order GetCustomerOrder(int id)
        {

            return OrderDBObject.GetCustomerOrder(id);

        }





    }
}

