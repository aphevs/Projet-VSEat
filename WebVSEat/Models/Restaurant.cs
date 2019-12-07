using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVSEat.Models
{
    public class Restaurant
    {
        [Required]
        public int IdRestaurant { get; set; }
        public DateTime created_at { get; set; }
        public string name { get; set; }
        public int IdCity { get; set; }
       

    }
}
