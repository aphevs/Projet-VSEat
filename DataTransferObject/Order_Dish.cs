using System;

namespace DataTransferObject
{
    public class Order_Dish
    {
        public int IdOrder { get; set; }
        public int quantity { get; set; }
        public int IdDish { get; set; }



        public override string ToString()
        {
            return $"{IdOrder}|{quantity}|{IdDish}";
        }
    }
}
