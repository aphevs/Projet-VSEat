using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace WebVSEat.Models
{
    public class Dish
    {
        public int IdDish { get; set; }
        public string NameDish { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public static decimal Total { get; set; }
    }

}
