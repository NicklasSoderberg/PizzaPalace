using PizzaPalace.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace PizzaPalace.ViewModels
{
    class PizzaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        

        public ObservableCollection<Pizza> Pizzas { get; set; }


        public PizzaViewModel()
        {
            Pizzas = new ObservableCollection<Pizza>();

            Pizza TPizza = new Pizza("Kebab", 49.99, false);
            Pizzas.Add(TPizza);
            TPizza = new Pizza("Vezuvio", 54.99, false);
            Pizzas.Add(TPizza);
            TPizza = new Pizza("Mafia", 59.99, false);
            Pizzas.Add(TPizza);
            TPizza = new Pizza("Bolognese", 59.99, false);
            Pizzas.Add(TPizza);
            TPizza = new Pizza("Italia Special", 64.99, false);
            Pizzas.Add(TPizza);
            TPizza = new Pizza("Veggiepizza", 84.99, true);
            Pizzas.Add(TPizza);
            TPizza = new Pizza("Margarita", 44.99, false);
            Pizzas.Add(TPizza);
            TPizza = new Pizza("Calabrese", 74.99, false);
            Pizzas.Add(TPizza);
        }

        
    }
}
