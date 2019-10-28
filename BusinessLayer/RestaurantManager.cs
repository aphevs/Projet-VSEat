using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class RestaurantManager
    {
        public IRestaurantsDB RestaurantDB { get; }


        public RestaurantManager(IConfiguration configuration)
        {
            RestaurantDB = new RestaurantsDB(configuration);

        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDB.GetRestaurants();

        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDB.GetRestaurant(id);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.AddRestaurant(restaurant);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.UpdateRestaurant(restaurant);
        }

        public int DeleteRestaurant(int id)
        {
            return RestaurantDB.DeleteRestaurant(id);
        }



    }
}

