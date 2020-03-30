using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Models
{
    public class GetUnDoneOrders
    {
        public int ID { get; set; }
        public string Phone { get; set; }
        public System.DateTime OrderTime { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
