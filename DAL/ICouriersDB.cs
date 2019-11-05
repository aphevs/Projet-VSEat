using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface ICouriersDB
    {
    
        IConfiguration Configuration { get; }

        List<Courier> GetCouriers();

        Courier GetCourier(int id);

        Courier AddCourier(Courier courier);

        int UpdateCourier(Courier courier);

        int DeleteCourier(int id);


    }
}
