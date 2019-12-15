using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebVSEat.Controllers
{
    public class DishController : Controller
    {


        private IDishManager DishManager { get; }


        public DishController(IDishManager dishManager)
        {
            DishManager = dishManager;
        }



        // GET: Dish
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dish/Details/5
        public ActionResult Details(int id)
        {

            var dish = DishManager.GetDish(id);
            return View(dish);
        }


        


    }
}