using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Models
{
    public partial class OrderInfo
    {
        public int ID { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Status { get; set; }
        public System.DateTime OrderTime { get; set; }
        public int Amount { get; set; }
    }
}
