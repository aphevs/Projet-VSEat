using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class DishManager : IDishManager
    {
        private IDishesDB DishDbObject { get; }
        public DishManager(IDishesDB dishDB)
        {
            DishDbObject = dishDB;
        }

        public int GetIdCityRestaurant(int id)
        {
            return DishDbObject.GetIdCityRestaurant(id);
        }


        public decimal GetPrice(int id)
        {
           return DishDbObject.GetPrice(id);
        }



        public Dish GetDish(int id)
        {
            return DishDbObject.GetDish(id);
        }

 
    }
}

