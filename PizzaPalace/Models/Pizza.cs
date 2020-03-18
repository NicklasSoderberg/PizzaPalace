using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Models
{
    class Pizza
    {
        public string Name {get; set;}
        public double Price { get; set; }
        public bool Vegan { get; set; }

        public Pizza(string setName, double setPrice, bool setVegan)
        {
            Name = setName;
            Price = setPrice;
            Vegan = setVegan;
        }
    }

    
}
