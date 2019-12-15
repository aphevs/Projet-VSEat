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
            ViewBag.id = HttpContext.Session.GetInt32("id");

            var orderlist = OrderManager.GetArchivedOrdersWithIdCourier(ViewBag.id);


            return View(orderlist);

        }


        public ActionResult GetCustomerOrders()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");


            var orderlist = OrderManager.GetCustomerOrdersWithIdCourier(ViewBag.id);


            return View(orderlist);



        }


        public ActionResult GetMyOrdersWithIdCustomer()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");

            var orderlist = OrderManager.GetMyOrdersWithIdCustomer(ViewBag.id);


            return View(orderlist);

        }


        public ActionResult GetMyOrdersWithIdCustomerError()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");

            var orderlist = OrderManager.GetMyOrdersWithIdCustomer(ViewBag.id);


            return View(orderlist);

        }


        //Cancel the order interface
        public ActionResult EditCustomer(int id)
        {
            var order = OrderManager.GetCustomerOrder(id);
            return View(order);
        }


        //delivered or cancelled interface
        public ActionResult Edit(int id)
        {
            var order = OrderManager.GetCustomerOrder(id);
            return View(order);
        }



        //update the order
        [HttpPost]
        public ActionResult EditCustomer(DataTransferObject.Order order)
        {

            var total = (order.created_at - DateTime.Now).TotalMinutes;


            if (total > 180) 
            {
            OrderManager.SetDelivered(order);
            return RedirectToAction(nameof(GetMyOrdersWithIdCustomer));
            }
            else
            {
                return RedirectToAction(nameof(GetMyOrdersWithIdCustomerError));
            }




        }

        //update the order - courier
        [HttpPost]
        public ActionResult Edit(DataTransferObject.Order order)
        {

            OrderManager.SetDelivered(order);
            return RedirectToAction(nameof(GetCustomerOrders));

        }


        //
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {

            var order = OrderManager.GetOrder(id);

            return View(order);
        }






    }
   }