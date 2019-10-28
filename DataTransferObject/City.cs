using System;

namespace DataTransferObject
{
    public class City
    {
        public int IdCity { get; set; }
        public int code { get; set; }
        public string name { get; set; }



        public override string ToString()
        {
            return $"{IdCity}|{code}|{name}";
        }
    }
}
