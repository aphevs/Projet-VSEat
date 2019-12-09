﻿using System;
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
        public OrderController(IOrderManager ordersManager)
        {
            OrderManager = ordersManager;
        }






        public ActionResult GetCurrentOrders()
        {
            try
            {

           
            var orderlist = OrderManager.GetCurrentOrders();

            return View(orderlist);
            }
            catch
            {
                return View();
            }


        }


        public ActionResult GetAllOrders()
        {

            var orderlist = OrderManager.GetOrders();

            return View(orderlist);


        }

        public ActionResult GetCustomerOrders()
        {

            var orderlist = OrderManager.GetCustomerOrders();

            return View(orderlist);


        }


        public ActionResult Edit(int id)
        {


            var order = OrderManager.GetOrder(id);
            return View(order);
        }



        [HttpPost]
        public ActionResult Edit(DataTransferObject.Order o)
        {


            OrderManager.UpdateOrder(o);
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

        //// GET: Order/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id)
        //{

        //    var order = OrderManager.UpdateOrder(id);
        //    return RedirectToAction(nameof(GetCurrentOrders));


        //}

        //// POST: Order/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //[HttpPost]
        //public ActionResult Edit(Order o)
        //{
            
        //    return RedirectToAction(nameof(GetCurrentOrders));
        //}



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