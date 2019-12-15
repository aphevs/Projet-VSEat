using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class Order_DishManager : IOrder_DishManager
    {
        private IOrder_DishesDB Order_DishDBObject { get; }


        public Order_DishManager(IOrder_DishesDB order_dishDB)
        {
            Order_DishDBObject = order_dishDB;

        }
        public decimal GetPriceByIdOrder(int id)
        {
            return Order_DishDBObject.GetPriceByIdOrder(id);
        }



        public Order_Dish GetOrder_Dish(int id)
        {
            return Order_DishDBObject.GetOrder_Dish(id);
        }




    }
}

