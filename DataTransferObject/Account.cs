using System;

namespace DataTransferObject
{
    public class Account
    {
        public int IdAccount { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public int customerAccount { get; set; }


        public override string ToString()
        {
            return $"{IdAccount}|{login}|{password}|{customerAccount}";
        }
    }
}
