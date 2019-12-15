using System.Collections.Generic;
using DataTransferObject;

namespace BusinessLayer
{
    public interface IRestaurantManager
    {

        List<Restaurant> GetRestaurantsFromCity(int id);

        List<int> GetCitiesId();

        List<Restaurant> GetRestaurantDishes(int id);
    }
}