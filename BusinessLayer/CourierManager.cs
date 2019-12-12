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

        public bool isCustomerValid(Courier cour)
        {
            //vérifie que le livreur est dans la liste des livreurs

            List<Courier> list = GetCouriers();

            foreach (var courier in list)
            {
                if (courier.login.Equals(cour.login) && courier.password.Equals(cour.password))
                    return true;
            }

            return false;

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

