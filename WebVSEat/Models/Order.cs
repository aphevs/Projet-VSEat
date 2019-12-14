using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace WebVSEat.Models
{
    public class Order
    {
        [Required]
        public int IdOrder { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime timeToDeliver { get; set; }
        public decimal totalprice { get; set; }
        public int IdCustomer { get; set; }
        public int IdCourier { get; set; }

    }
}
