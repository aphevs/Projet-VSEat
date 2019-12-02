using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject;

namespace DAL
{
    public interface ISchedulesDB
    {
    
       // IConfiguration Configuration { get; }


        Schedule GetSchedule(int id);



    }
}
