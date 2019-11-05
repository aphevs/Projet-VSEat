using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class ScheduleManager
    {
        public ISchedulesDB ScheduleDB { get; }


        public ScheduleManager(IConfiguration configuration)
        {
            ScheduleDB = new SchedulesDB(configuration);
        }

        

        public Schedule GetSchedule(int id)
        {
            return ScheduleDB.GetSchedule(id);
        }


    }
}

