using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebVSEat.Controllers
{
    public class OrderController : Controller
    {

        private IOrderManager OrderManager { get; }
        public OrderController(IOrderManager ordersManager)
        {
            OrderManager = ordersManager;
        }



        public ActionResult GetArchivedOrders()
        {
            //ViewBag.id = HttpContext.Session.GetInt32("id"); //id de alex, le courier

            var orderlist = OrderManager.GetCustomerOrders();

            return View(orderlist);
           
        }


        public ActionResult GetCustomerOrders()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");

            //int id = (int)ViewBag.id;

            //TEST WITH ID 2, IT'S ALEXANDREP
            //var orderlist = OrderManager.GetCustomerOrdersWithIdCourier(2);

            //TEST TEST TEST
            var orderlist = OrderManager.GetCustomerOrders();

            return View(orderlist);



        }


        public ActionResult Edit(int id)
        {
            var order = OrderManager.GetCustomerOrder(id);
            return View(order);
        }



        [HttpPost]
        public ActionResult Edit(DataTransferObject.Order order)
        {

            OrderManager.SetDelivered(order);
            return RedirectToAction(nameof(GetCustomerOrders));

        }



        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {

            var order = OrderManager.GetOrder(id);

            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
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




        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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



    }
}