using PizzaPalace.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzaPalace.ViewModels
{
    class OrderPageModel : INotifyPropertyChanged
    {
        private bool gotMenu = false;
        
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

        public ObservableCollection<Models.MenuItem> Order { get; set; }
        public ObservableCollection<Models.MenuItem> MenuItems { get; set; }
        public List<Models.MenuItem> APIMenuItems { get; set; }
        
        public OrderPageModel()
        {
            MenuItems = new ObservableCollection<Models.MenuItem>();
            Order = new ObservableCollection<Models.MenuItem>();
        }

        public void API_Menu()
        {
            Constants BaseURL = new Constants();
            string URL = BaseURL.getBaseURL() + "/menu";
            try
            {
                var client = new HttpClient();
                var response = client.GetStringAsync(URL).Result;
                APIMenuItems = JsonConvert.DeserializeObject<List<Models.MenuItem>>(response);
                gotMenu = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public void API_Ingrediens()
        {
            Constants BaseURL = new Constants();
            string URL = BaseURL.getBaseURL() + "/menu/";
            for(int i = 0; i < APIMenuItems.Count; i++)
            {
                APIMenuItems[i].string_Ingredienser = "";
                try
                {
                    var client = new HttpClient();
                    var response = client.GetStringAsync(URL + (i+1).ToString()).Result;
                    APIMenuItems[i].Ingredienser = JsonConvert.DeserializeObject<List<string>>(response);
                    for(int ii = 0; ii < APIMenuItems[i].Ingredienser.Count; ii++)
                    {
                        if (APIMenuItems[i].string_Ingredienser.Length > 0)
                        {
                            APIMenuItems[i].string_Ingredienser += ", " + APIMenuItems[i].Ingredienser[ii];
                        }
                        else
                        {
                            APIMenuItems[i].string_Ingredienser += APIMenuItems[i].Ingredienser[ii];
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }

        public ObservableCollection<Models.MenuItem> getMenu(bool isVeggan, bool isPizza, bool isOther)
        {
            if (!gotMenu)
            {
                API_Menu();
                API_Ingrediens();
            }
            List<Models.MenuItem> returnThis = new List<Models.MenuItem>();
            List<Models.MenuItem> T = APIMenuItems;

            bool[] boolArr = { isVeggan, isPizza, isOther };
            string[] stringArr = { "Vegan", "Pizza", "Other" };

            for (int i = 0; i < T.Count(); i++)
            {
                for (int ii = 0; ii < boolArr.Length; ii++)
                if(boolArr[ii] && T[i].Type == stringArr[ii])
                {
                    returnThis.Add(T[i]);
                    break;
                }
            }
            return new ObservableCollection<Models.MenuItem>(returnThis);
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
