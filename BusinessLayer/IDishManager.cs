using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface IDishManager
    {

        // IDishesDB DishDb { get; }

        decimal GetPrice(int id);

        int GetIdCityRestaurant(int id);

        Dish GetDish(int id);


       
    }
}