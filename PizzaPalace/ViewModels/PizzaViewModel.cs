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

        public int order_TotalNumberOfPizzas = 0;
        public int Order_TotalNumberOfPizzas
        {
            get => order_TotalNumberOfPizzas;
            set
            {
                order_TotalNumberOfPizzas = value;
                OnPropertyChanged(nameof(Order_TotalNumberOfPizzas));
            }
        }

        public int order_TotalAmount = 0;
        public int Order_TotalAmount
        {
            get => order_TotalAmount;
            set
            {
                order_TotalAmount = value;
                OnPropertyChanged(nameof(Order_TotalAmount));
            }
        }

        bool showVegan = true;
        public bool ShowVegan
        {
            get => showVegan;
            set
            {
                showVegan = value;
                MenuItems = getMenu(showVegan, showPizza, showOther);
                OnPropertyChanged(nameof(ShowVegan));
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        bool showPizza = true;
        public bool ShowPizza
        {
            get => showPizza;
            set
            {
                showPizza = value;
                MenuItems = getMenu(showVegan, showPizza, showOther);
                OnPropertyChanged(nameof(ShowPizza));
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        bool showOther = true;
        public bool ShowOther
        {
            get => showOther;
            set
            {
                showOther = value;
                MenuItems = getMenu(showVegan, showPizza, showOther);
                OnPropertyChanged(nameof(ShowOther));
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Pizza> Order { get; set; }
        /*public ObservableCollection<Pizza> Order
        {
            get => order;
            set
            {
                order = value;
                Order_TotalAmount = order_Calculate();
                Order_TotalNumberOfPizzas = order_NumberInCart();
                OnPropertyChanged(nameof(Order));
                OnPropertyChanged(nameof(Order_TotalAmount));
                OnPropertyChanged(nameof(Order_TotalNumberOfPizzas));
            }
        }*/

        public ObservableCollection<Pizza> MenuItems { get; set; }

        public PizzaViewModel()
        {
            MenuItems = new ObservableCollection<Pizza>();
            Order = new ObservableCollection<Pizza>();
        }

        public ObservableCollection<Pizza> getMenu(bool isVeggan, bool isPizza, bool isOther)
        {
            ObservableCollection<Pizza> tempList = new ObservableCollection<Pizza>();

            if (isVeggan)
            {
                tempList.Add(new Pizza("Veggiepizza", 84));
            }

            if (isPizza)
            {
                tempList.Add(new Pizza("Vezuvio", 54));
                tempList.Add(new Pizza("Kebab", 49));
                tempList.Add(new Pizza("Mafia", 59));
                tempList.Add(new Pizza("Bolognese", 59));
                tempList.Add(new Pizza("Italia Special", 64));
                tempList.Add(new Pizza("Margarita", 44));
                tempList.Add(new Pizza("Calabrese", 74));
            }

            if (isOther)
            {
                tempList.Add(new Pizza("Pasta", 74));
            }

            return tempList;
        }

        public int order_Calculate()
        {
            int tCalc = 0;
            for(int i = 0; i < Order.Count; i++)
            {
                tCalc = tCalc + Order[i].Price;
            }
            return tCalc;
        }

        public int order_NumberInCart()
        {
            return Order.Count;
        }

    }
}
