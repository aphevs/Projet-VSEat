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
        List<Restaurant> GetRestaurantsFromCity(int id);
        List<Restaurant> GetRestaurantDishes(int id);



    }
}
