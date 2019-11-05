using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class Courier
    {
        public int IdCourier { get; set; }
        public string name { get; set; }      
        public DateTime created_at { get; set; }
        public int IdCity { get; set; }

        public string streetname { get; set; }

        public int IdAccount { get; set; }


        public override string ToString()
        {
            return $"{IdCourier}|{name}|{created_at}|{IdCity}|{streetname}|{IdAccount}";
        }
    }
}
