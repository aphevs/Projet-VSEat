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


       // }
        //if you have an object, you can get here, if not, you stay out
        public ActionResult Details(int id)
        {

           
            var restaurant = RestaurantManager.GetRestaurant(id);
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

        public ActionResult GetRestaurants()
        {
            var restaurantList = new List<Restaurant>
            {
            new Restaurant() {IdRestaurant = 1, created_at = new DateTime(2008, 3, 1, 7, 0, 0), name = "Vache and me", IdCity =1, IdSchedule = 1 },
            new Restaurant() {IdRestaurant = 2, created_at = new DateTime(2009, 7, 10, 0, 0, 0), name = "Downtown", IdCity =2, IdSchedule = 1 },
            new Restaurant() {IdRestaurant = 3, created_at = new DateTime(2014, 4, 10, 0, 0, 0), name = "SAP", IdCity =1, IdSchedule = 1 },
            new Restaurant() {IdRestaurant = 4, created_at = new DateTime(2018, 7, 11, 0, 0, 0), name = "San Andreas", IdCity =1, IdSchedule = 1 },
            };
            return View();

        }

        public ActionResult GetCityRestaurants()
        {
            var restaurantList = new List<CityRestaurants>
            {
                new CityRestaurants() {city = "Sierre", lrestaurants = new List<Restaurant>{
                new Restaurant() {Name ="Vache and me" },
                new Restaurant() {Name = "Downtown" },
                new Restaurant() {Name = "Team"},
                }}
            };
            return View("GetCityRestaurants", restaurantList);

        }



        //use with bll import
        public ActionResult GetAllRestaurants()
        {
            

            var restaurantlist = RestaurantManager.GetRestaurants();


            return View(restaurantlist);


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
            return RedirectToAction(nameof(Index));




        }




    }
}