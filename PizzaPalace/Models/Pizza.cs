using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Models
{
    class Pizza
    {
        public string Name {get; set;}
        public int Price { get; set; }
        public Pizza(string setName, int setPrice)
        {
            Name = setName;
            Price = setPrice;
        }
    }

    
}
