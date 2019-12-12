using System;

namespace DataTransferObject
{
    public class Dish
    {
        public int IdDish { get; set; }
        public string nameDish { get; set; }
        public decimal price { get; set; }

        public string description { get; set; }

        public int IdRestaurant { get; set; }

    }
}
