using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class CourierManager : ICourierManager
    {
        private ICouriersDB CouriersDbObject { get; }

        public CourierManager(ICouriersDB couriersDB)
        {
            CouriersDbObject = couriersDB;
        }


        public Courier GetCourierByUsernamePassword(string login, string password)
        {
            return CouriersDbObject.GetCourierByUsernamePassword(login, password);
        }



        public List<Courier> GetCouriers()
        {
            return CouriersDbObject.GetCouriers();
        }

        public Courier GetCourier(int id)
        {
            return CouriersDbObject.GetCourier(id);
        }

        public Courier AddCourier(Courier courier)
        {
            return CouriersDbObject.AddCourier(courier);
        }


        public int UpdateCourier(Courier courier)
        {
            return CouriersDbObject.UpdateCourier(courier);
        }

        public int DeleteCourier(int id)
        {
            return CouriersDbObject.DeleteCourier(id);
        }


    }
}

