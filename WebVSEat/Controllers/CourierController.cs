using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebVSEat.Controllers
{
    public class CourierController : Controller
    {
      
        private ICourierManager CourierManager { get; }

        public CourierController(ICourierManager courierManager)
        {
            CourierManager = courierManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Courier cour)
        {
            Courier courier = CourierManager.GetCourierByUsernamePassword(cour.login, cour.password);

            if (courier != null)
            {
                HttpContext.Session.SetInt32("id", courier.IdCourier);
                HttpContext.Session.SetString("name", courier.name);
                return RedirectToAction("GetCustomerOrders", "Order");
            }
            else
            {
                return RedirectToAction("Login","Courier");
            }
        }






        // GET: Courier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Courier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Courier/Create
        public ActionResult Create()
        {
            return View();
        }

       
    }
}