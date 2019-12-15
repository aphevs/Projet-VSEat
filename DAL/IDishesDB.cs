using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IDishesDB
    {

       // IConfiguration Configuration { get; }

        List<Dish> GetDishes();


        decimal GetPrice(int id);

        int GetIdCityRestaurant(int id);

        Dish GetDish(int id);

        Dish AddCustomer(Dish dish);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);
       
        Dish AddDish(Dish dish);
       
    }
}
