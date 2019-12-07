using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
        public int IdCustomer { get; set; }
        public int IdCourier { get; set; }
    }
}
