using System;

namespace DataTransferObject
{
    public class Dish
    {
        public int IdDish { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public string status { get; set; }

        public DateTime created_at { get; set; }

        public int IdRestaurant { get; set; }


        public override string ToString()
        {
            return $"{IdDish}|{name}|{price}|{status}|{created_at}|{IdRestaurant}";
        }
    }
}
