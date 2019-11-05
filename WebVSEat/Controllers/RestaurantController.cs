using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebVSEat.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRestaurants()
        {

            return View();

        }



        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //if you have an object, you can get here, if not, you stay out
        [HttpPost]
        public ActionResult Details(DataTransferObject.Restaurant r)
        {
            DataTransferObject.Restaurant restaurant = r;
            return View();
        }


        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult IndexRestaurant()
        {
            var restaurantList = new List<DataTransferObject.Restaurant>
            {
            new DataTransferObject.Restaurant() {IdRestaurant = 1, created_at = new DateTime(2008, 3, 1, 7, 0, 0), name = "Vache and me", IdCity =1, IdSchedule = 1 },
            new DataTransferObject.Restaurant() {IdRestaurant = 2, created_at = new DateTime(2009, 7, 10, 0, 0, 0), name = "Downtown", IdCity =2, IdSchedule = 1 },
            new DataTransferObject.Restaurant() {IdRestaurant = 3, created_at = new DateTime(2014, 4, 10, 0, 0, 0), name = "SAP", IdCity =1, IdSchedule = 1 },
            new DataTransferObject.Restaurant() {IdRestaurant = 4, created_at = new DateTime(2018, 7, 11, 0, 0, 0), name = "San Andreas", IdCity =1, IdSchedule = 1 },
            };
            return View();

        }
    }
}