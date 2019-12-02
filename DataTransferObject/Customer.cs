using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string name { get; set; }      
        public DateTime created_at { get; set; }
        public int IdCity { get; set; }

        public string streetname { get; set; }

        public int IdAccount { get; set; }


        public string login { get; set; }
        public string password { get; set; }
        public bool customerAccount { get; set; }


        public override string ToString()
        {
            return $"{IdCustomer}|{name}|{created_at}|{IdCity}|{streetname}|{IdAccount}";
        }
    }
}
