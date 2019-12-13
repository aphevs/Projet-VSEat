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
        List<Courier> GetCouriers();

        Courier GetCourierByUsernamePassword(string login, string password);

        Courier GetCourier(int id);

        Courier AddCourier(Courier courier);

        int UpdateCourier(Courier courier);

        int DeleteCourier(int id);

    }
}