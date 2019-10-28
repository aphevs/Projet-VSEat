using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface IDishesDB
    {

        IConfiguration Configuration { get; }

        List<Dish> GetDishes();

        Dish GetDish(int id);

        Dish AddCustomer(Dish dish);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);

    }
}
