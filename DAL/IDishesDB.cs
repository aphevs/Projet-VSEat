using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IDishesDB
    {


        decimal GetPrice(int id);

        int GetIdCityRestaurant(int id);

        Dish GetDish(int id);


       
    }
}
