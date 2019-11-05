using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class CourierManager
    {
        public ICouriersDB CourierDB { get; }


        public CourierManager(IConfiguration configuration)
        {
            CourierDB = new CouriersDB(configuration);
        }

        public List<Courier> GetCouriers()
        {
            return CourierDB.GetCouriers();
        }

        public Courier GetCourier(int id)
        {
            return CourierDB.GetCourier(id);
        }

        public Courier AddCourier(Courier courier)
        {
            return CourierDB.AddCourier(courier);
        }


        public int UpdateCourier(Courier courier)
        {
            return CourierDB.UpdateCourier(courier);
        }

        public int DeleteCourier(int id)
        {
            return CourierDB.DeleteCourier(id);
        }



    }
}

