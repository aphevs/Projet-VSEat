using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface ICourierManager
    {

        ICouriersDB CouriersDb { get; }

        List<Courier> GetCouriers();

        Courier GetCourier(int id);

        Courier AddCourier(Courier courier);

        int UpdateCourier(Courier courier);

        int DeleteCourier(int id);

    }
}