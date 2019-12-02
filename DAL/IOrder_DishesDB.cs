using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IOrder_DishesDB
    {

        //IConfiguration Configuration { get; }


        Order_Dish GetOrder_Dish(int id);



    }
}
