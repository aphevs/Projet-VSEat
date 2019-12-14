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
       


        public RestaurantController(IRestaurantManager restaurantManager)
        {
            RestaurantManager = restaurantManager;

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

            ViewBag.Price = HttpContext.Session.GetInt32("price");
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



        //public ActionResult ConfirmOrder(string name, decimal price)
        //{

        //    new Order() {IdOrder = HttpContext. + ViewBag["lastname"], status = "non delivered", created_at= DateTime.Now,  };

        //    HttpContext.Session.SetInt32("id", customer.IdCustomer);
        //    HttpContext.Session.SetString("name", customer.name);

        //}

        public static List<Dish> cartlist = new List<Dish>();

        public ActionResult Cart(int id, string name, decimal price)
        {




            if (name != null && price > 0)
            {

                //if the list is not empty, add a new object, if the dish is already in the cart, just add +1 to the quantity

                //if (cartlist.Any(i => i.NameDish == name))
                //{
                //    cartlist[i] = new Dish { IdDish = id, NameDish = name, Price = price, Quantity+=1 };
                //}
                // else
                //{
                    cartlist.Add(new Dish { IdDish = id, NameDish = name, Price = price, Quantity = 1 });
                //}







            }


            return View("Cart", cartlist);

            //ViewBag.id = id;
            //ViewBag.name = name;
            //ViewBag.price = price;


            //    var restaurantList = new List<CityRestaurants>
            //    {
            //        new CityRestaurants() {city = "Sierre", lrestaurants = new List<Restaurant>{
            //        new Restaurant() {Name ="Vache and me" },
            //        new Restaurant() {Name = "Downtown" },
            //        new Restaurant() {Name = "Team"},
            //        }}
            //    };
            //    return View("GetCityRestaurants", restaurantList);


            //HttpContext.Session.SetInt32("Sessioniddish", id);
            //HttpContext.Session.SetString("Sessiondishname", name);
            //HttpContext.Session.Set<decimal>("Sessionprice", price);

        }


        public ActionResult ConfirmOrder(decimal total, int quantity)
        {
            ViewBag.total = total;
            ViewBag.quantity = quantity;


            return View();
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