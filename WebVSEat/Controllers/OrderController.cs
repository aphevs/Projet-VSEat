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
    public class OrderController : Controller
    {

        private IOrderManager OrderManager { get; }
        private IOrder_DishManager Order_DishManager { get; }
        public OrderController(IOrderManager ordersManager, IOrder_DishManager order_DishManager)
        {
            OrderManager = ordersManager;

            Order_DishManager = order_DishManager;
        }


        //For the courier who is logged
        public ActionResult GetArchivedOrders()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");

            var orderlist = OrderManager.GetArchivedOrdersWithCourier(ViewBag.id);

            return View(orderlist);

        }

        //For the courier who is logged
        public ActionResult GetCustomerOrders()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");


            var orderlist = OrderManager.GetCustomerOrdersWithIdCourier(ViewBag.id);


            return View(orderlist);



        }

        //For the customer who is logged
        //It also calculates the total of each order
        public ActionResult GetMyOrdersWithIdCustomer()
        {

            ViewBag.id = HttpContext.Session.GetInt32("id");
            //var orderlist = OrderManager.GetMyOrdersWithIdCustomer(ViewBag.id);
            List<Order> orderlist = OrderManager.GetMyOrdersWithIdCustomer(ViewBag.id);

            List<decimal> total = new List<decimal>();
            foreach(var i in orderlist)
            {
                total.Add(Order_DishManager.GetPriceByIdOrder(i.IdOrder));
            }

            ViewBag.total = total;


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
 