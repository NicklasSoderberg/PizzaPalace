using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Models
{
    public class CompleteOrder
    {
        public OrderInfo NewOrderInfo { get; set; }
        public List<OrderInfoItem> OrderList { get; set; }
    }
}
