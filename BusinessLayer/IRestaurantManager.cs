using System.Collections.Generic;
using DataTransferObject;

namespace BusinessLayer
{
    public interface IRestaurantManager
    {


        List<Restaurant> GetRestaurants();

        Restaurant GetRestaurant(int id);

        Restaurant AddRestaurant(Restaurant restaurant);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);

    }
}