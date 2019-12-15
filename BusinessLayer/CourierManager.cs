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



    }
}

