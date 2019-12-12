using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IRestaurantsDB
    {
    
        List<Restaurant> GetRestaurants();

        Restaurant GetRestaurant(int id);

        List<Restaurant> GetRestaurantsFromCity(int id);

        List<Restaurant> GetRestaurantDishes(int id);

        Restaurant AddRestaurant(Restaurant restaurant);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);


    }
}
