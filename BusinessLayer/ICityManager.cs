using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface ICityManager
    {

        ICitiesDB CitiesDb { get; }

        Customer GetCustomer(int id);

    }
}