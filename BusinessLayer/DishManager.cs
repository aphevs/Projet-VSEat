using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class DishManager
    {
        public IDishesDB DishDB { get; }


        public DishManager(IConfiguration configuration)
        {
            DishDB = new DishesDB(configuration);
        }

        public List<Dish> GetDishes()
        {
            return DishDB.GetDishes();
        }

        public Dish GetDish(int id)
        {
            return DishDB.GetDish(id);
        }

        public Dish AddDish(Dish dish)
        {
            return DishDB.AddDish(dish);
        }


        public int UpdateDish(Dish dish)
        {
            return DishDB.UpdateDish(dish);
        }

        public int DeleteDish(int id)
        {
            return DishDB.DeleteDish(id);
        }



    }
}

