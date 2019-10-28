using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class CityManager
    {
        public ICitiesDB CityDB { get; }


        public CityManager(IConfiguration configuration)
        {
           CityDB = new CitiesDB(configuration);

        }

        

        public City GetCity(int id)
        {
            return CityDB.GetCity(id);
        }


    }
}

