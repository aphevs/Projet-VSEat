using System;
using System.Collections.Generic;
using System.Text;

namespace WebVSEat.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public string comment { get; set; }
        public int IdCustomer { get; set; }
        public int IdCourier { get; set; }
        public int IdCity { get; set; }

    }
}
