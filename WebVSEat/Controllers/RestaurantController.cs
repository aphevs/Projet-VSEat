using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebVSEat.Models;
using BusinessLayer;
using Microsoft.Extensions.Configuration;

namespace WebVSEat.Controllers
{
    public class RestaurantController : Controller
    {

        private IRestaurantManager RestaurantManager { get; }
        private IDishManager DishManager { get; }
        private IOrderManager OrderManager { get; }


        public RestaurantController(IRestaurantManager restaurantManager, IDishManager dishManager, IOrderManager orderManager)
        {
            RestaurantManager = restaurantManager;

            DishManager = dishManager;

            OrderManager = orderManager;
        }

        
        public ActionResult ConfirmationOrder(IFormCollection fc)
        {
            int[] id_dishes = Array.ConvertAll(fc["nameDish"].ToString().Split(','),
                s => int.TryParse(s, out var i) ? i : 0);

            int[] quantity = Array.ConvertAll(fc["quantity"].ToString().Split(','),
                s => int.TryParse(s, out var i) ? i : 0);


            //With Dictionary, we have a list of two int "linked".
            //That's the object dish and its quantity
            Dictionary<int, int> dishes = id_dishes.Zip(quantity, (s, i) => new { s, i })
                          .ToDictionary(item => item.s, item => item.i);


            //Calculating the total price the customer will have to pay, and give it to the courrier in the right city
            decimal total = 0;
            int idCit=0;
            foreach (var i in dishes)
            {
                if(i.Value != 0)
                {
                    total += DishManager.GetPrice(i.Key) * i.Value;
                    idCit = DishManager.GetIdCityRestaurant(i.Key);
                }



            }
           


            //Taking the dateTime and stocking it in the variable dat
            DateTime dat = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
               Int32.Parse(fc["hour"]), Int32.Parse(fc["min"]), 0);


            //CHECK if the date is higher than now and if the total isn't zero. 
            //That means the customer has choosen something for a correct/possible delivery time
            if (dat > DateTime.Now && total != 0)
            {

                OrderManager.SetOrder(dishes, idCit, Convert.ToInt32(HttpContext.Session.GetInt32("id")), dat);
                ViewBag.total = total;
                ViewBag.dat = dat;
                return View();
            }
           


            else
             {
                return RedirectToAction(nameof(OrderError));
            }

        }

        public ActionResult OrderError()
        {
            return View();
        }


        //The view to search a restaurant with a city code
        public ActionResult Index()
        {
            return View();
        }

        //The view returned if the code is not in the database or is incorrect
        public ActionResult IndexError()
        {
            return View();
        }

        //Getting the dishes of a given restaurant
        public ActionResult GetRestaurantDishes(int id)
        {

            var restaurant = RestaurantManager.GetRestaurantDishes(id);
            return View(restaurant);

        }


        //Search a city code and get all the restaurants inside

        [HttpPost]
        public ActionResult GetAllRestaurantsFromCity(int id)
        {

            var cityidlist = RestaurantManager.GetCitiesId();
            bool validCityId = false;


           //if the city code is not in the database or not correct, it display a the index error view
            foreach (int index in cityidlist)
            {

                if (id == index)
                    validCityId = true;

            }

            if (validCityId == true)
            {

                var restaurantlist = RestaurantManager.GetRestaurantsFromCity(id);

                return View(restaurantlist);

            }
            else
            {


                return RedirectToAction(nameof(IndexError));


            }

        }




    }
}