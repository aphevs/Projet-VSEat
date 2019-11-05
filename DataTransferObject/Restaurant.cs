using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class Restaurant
    {
        public int IdRestaurant { get; set; }
        public DateTime created_at { get; set; }
        public int IdCity { get; set; }
        public string name { get; set; }
        public int IdSchedule { get; set; }

        public override string ToString()
        {
            return $"{IdRestaurant}|{created_at}|{IdCity}|{name}|{IdSchedule}";
        }
    }
}
