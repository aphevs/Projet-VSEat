using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class Order
    {
        public decimal total;

        public int IdOrder { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime timeToDeliver { get; set; }
        public int IdCustomer { get; set; }
        public int IdCourier { get; set; }



        //get orders and customer info
        public string name { get; set; }
        public string lastname { get; set; }
        public string streetname { get; set; }
        public int IdCity { get; set; }
    }
}
