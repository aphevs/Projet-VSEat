using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface ICitiesDB
    {
    
        IConfiguration Configuration { get; }


        City GetCity(int id);



    }
}
