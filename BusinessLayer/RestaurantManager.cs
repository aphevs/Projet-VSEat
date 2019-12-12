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


        public List<Restaurant> GetRestaurantDishes(int id)
        {
            return RestaurantDBObject.GetRestaurantDishes(id);
        }



        public List<Restaurant> GetRestaurantsFromCity(int id)
        {
            return RestaurantDBObject.GetRestaurantsFromCity(id);

        }


        //This is used to check if the city is or not in the database 

        public List<int> GetCitiesId()
        {

            List<int> lidcity = null;
            List<Restaurant> lCities = RestaurantDBObject.GetRestaurants();

            foreach(Restaurant restaurant in lCities)
            {
                if (lidcity == null)
                    lidcity = new List<int>();

                lidcity.Add(restaurant.IdCity);

            }

            return lidcity;


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

