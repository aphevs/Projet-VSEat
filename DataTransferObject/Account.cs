using System;

namespace DataTransferObject
{
    public class Account
    {
        public int IdAccount { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool customerAccount { get; set; }

        /*
        public int IdCustomer { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public int IdCity { get; set; }

        public string streetname { get; set; }
        */

        public override string ToString()
        {
            return $"{IdAccount}|{login}|{password}|{customerAccount}";
        }
    }
}
