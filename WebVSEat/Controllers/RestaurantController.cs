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


            //Calculating the total price the customer will have to pay, and the city where the courier 
            //will be attached to (alex corrige cette phrase c'est 2h du mat)
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


            //CHECK if the date is upper than now and if the total isn't zero. 
            //That means the customer has choosed something for a correct/possible livraison time
            if (dat > DateTime.Now && total != 0)
            {
                //probleme ici avec le idCity du restau !! il faudra mettre idCity 1,2,3 et pas le code postal
                //ou alors trouver solution car jpp comme certains disent

                OrderManager.SetOrder(dishes, idCit, Convert.ToInt32(HttpContext.Session.GetInt32("id")), dat);
                ViewBag.total = total;
                ViewBag.dat = dat;
                return View();
            }
            return RedirectToAction("GetRestaurantDishes");





        }







        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IndexError()
        {
            return View();
        }

        //Create a list déroulante
        //selected = par défaut
        // GET: Restaurant/Details/5
        // public ActionResult Details(int id)
        // {

        // var names = new List<SelectListItem>
        // {
        //     new SelectListItem{Value="1", Text = "Vache and me"},
        //     new SelectListItem{Value="2", Text = "Downtown", Selected=true},
        //      new SelectListItem{Value="3", Text = "Thai"}
        // };
        // ViewBag.Names = names;
        // ViewBag.Selected = 2;
        // return View();


        //Getting the dishes of a given restaurant
        public ActionResult GetRestaurantDishes(int id)
        {

           
            var restaurant = RestaurantManager.GetRestaurantDishes(id);
            return View(restaurant);

        }


        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DataTransferObject.Restaurant r)
        {
            try
            {
               
                RestaurantManager.AddRestaurant(r);

                return RedirectToAction(nameof(GetAllRestaurants));
            }
            catch
            {
                return View();
            }
        }




        // GET: Restaurant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            RestaurantManager.DeleteRestaurant(id);
            return View(RedirectToAction(nameof(GetAllRestaurants)));

        }

        // POST: Restaurant/Delete/5
       // [HttpPost]
    //    [ValidateAntiForgeryToken]
       // public ActionResult Delete(int id, IFormCollection collection)
        //{
       //     try
       //     {
                // TODO: Add delete logic here

      //          return RedirectToAction(nameof(Index));


        //    }
       //     catch
      //      {
      //          return View();
     //       }
     //   }

        //public ActionResult GetRestaurants()
        //{
        //    var restaurantList = new List<Restaurant>
        //    {
        //    new Restaurant() {IdRestaurant = 1, created_at = new DateTime(2008, 3, 1, 7, 0, 0), name = "Vache and me", IdCity =1 },
        //    new Restaurant() {IdRestaurant = 2, created_at = new DateTime(2009, 7, 10, 0, 0, 0), name = "Downtown", IdCity =2},
        //    new Restaurant() {IdRestaurant = 3, created_at = new DateTime(2014, 4, 10, 0, 0, 0), name = "SAP", IdCity =1},
        //    new Restaurant() {IdRestaurant = 4, created_at = new DateTime(2018, 7, 11, 0, 0, 0), name = "San Andreas", IdCity =1 },
        //    };
        //    return View();

        //}

        //public ActionResult GetCityRestaurants()
        //{
        //    var restaurantList = new List<CityRestaurants>
        //    {
        //        new CityRestaurants() {city = "Sierre", lrestaurants = new List<Restaurant>{
        //        new Restaurant() {Name ="Vache and me" },
        //        new Restaurant() {Name = "Downtown" },
        //        new Restaurant() {Name = "Team"},
        //        }}
        //    };
        //    return View("GetCityRestaurants", restaurantList);

        //}



        //use with bll import
        public ActionResult GetAllRestaurants()
        {

            var restaurantlist = RestaurantManager.GetRestaurants();

            ViewBag.id = HttpContext.Session.GetInt32("id");

            return View(restaurantlist);


        }




        //Search a city code and get all the city inside

        [HttpPost]
        public ActionResult GetAllRestaurantsFromCity(int id)
        {

            var cityidlist = RestaurantManager.GetCitiesId();
            bool validCityId = false;

            foreach (int index in cityidlist)
            {

                if (id == index)
                    validCityId = true;

            }

            if(validCityId==true)
            { 

            var restaurantlist = RestaurantManager.GetRestaurantsFromCity(id);

            return View(restaurantlist);

            }
            else
            {


                return RedirectToAction(nameof(IndexError));


            }




        }



        // GET: Restaurant/Edit/5
        //restaurant DTO
        public ActionResult Edit(int id)
        {
           
            var restaurant = RestaurantManager.GetRestaurant(id);
            return View(restaurant);
        }



         [HttpPost]
        public ActionResult Edit(DataTransferObject.Restaurant r)
        {
            RestaurantManager.UpdateRestaurant(r);
            return RedirectToAction(nameof(GetAllRestaurants));


        }




    }
}