using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DataTransferObject;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public interface IScheduleManager
    {

        ISchedulesDB SchedulesDb { get; }

        Schedule GetSchedule(int id);

    }
}