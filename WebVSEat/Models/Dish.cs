using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace WebVSEat.Models
{
    public class Dish
    {
        public int IdDish { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }

        public string description { get; set; }

        public int IdRestaurant { get; set; }

    }
}
