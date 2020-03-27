using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Models
{
    class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public List<string> Ingredienser { get; set; }

        public string string_Ingredienser { get; set; }

        public MenuItem(int setID, string setName, string setType, int setPrice)
        {
            ID = setID;
            Name = setName;
            Type = setType;
            Price = setPrice;
        }
    }
}



    

