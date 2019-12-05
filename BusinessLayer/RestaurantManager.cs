using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class RestaurantManager : IRestaurantManager
    {
        private IRestaurantsDB RestaurantDBObject { get; }


        public RestaurantManager(IRestaurantsDB restaurantDB)
        {
            RestaurantDBObject = restaurantDB;

        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDBObject.GetRestaurants();

        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDBObject.GetRestaurant(id);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDBObject.AddRestaurant(restaurant);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDBObject.UpdateRestaurant(restaurant);
        }


        public int DeleteRestaurant(int id)
        {
            return RestaurantDBObject.DeleteRestaurant(id);
        }



    }
}

