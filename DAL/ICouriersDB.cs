using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface ICouriersDB
    {

        List<Courier> GetCouriers();

        Courier GetCourierByUsernamePassword(string login, string password);

        Courier GetCourier(int id);

        Courier AddCourier(Courier courier);

        int UpdateCourier(Courier courier);

        int DeleteCourier(int id);


    }
}
