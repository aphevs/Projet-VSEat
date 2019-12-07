using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class CityManager : ICityManager
    {

        private ICitiesDB CitiesDbObject { get; }

        public CityManager(ICitiesDB citiesDB)
        {
            CitiesDbObject = citiesDB;
        }



        public City GetCity(int id)
        {
            return CitiesDbObject.GetCity(id);
        }


    }
}

