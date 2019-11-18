using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVSEat.Models
{
    public class Restaurant
    {
        public int IdRestaurant { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        public int IdCity { get; set; }
        public string name { get; set; }
        public string Name { get; internal set; }
        public int IdSchedule { get; set; }

        public override string ToString()
        {
            return $"{IdRestaurant}|{created_at}|{IdCity}|{name}|{IdSchedule}";
        }
    }
}
