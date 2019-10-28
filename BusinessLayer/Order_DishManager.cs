using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class Order_DishManager
    {
        public IOrder_DishesDB Order_DishDB { get; }


        public Order_DishManager(IConfiguration configuration)
        {
            Order_DishDB = new Order_DishesDB(configuration);

        }


        public Order_Dish GetOrder_Dish(int id)
        {
            return Order_DishDB.GetOrder_Dish(id);
        }




    }
}

