using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class Customer
    {
        public int idCustomer { get; set; }
        public string name { get; set; }      
        public DateTime created_at { get; set; }
        public int idCity { get; set; }

        public string streetname { get; set; }


        public override string ToString()
        {
            return $"{idCustomer}|{name}|{created_at}|{idCity}|{streetname}";
        }
    }
}
