using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface IOrder_DishManager
    {

        // IOrder_DishesDB Order_DishesDb { get; }

        decimal GetPriceByIdOrder(int id);
        Order_Dish GetOrder_Dish(int id);

    }
}