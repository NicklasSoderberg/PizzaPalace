using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PizzaPalace.ViewModels;

namespace PizzaPalace
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private PizzaViewModel PizzaObject;

        public MainPage()
        {
            InitializeComponent();
            PizzaObject = new PizzaViewModel();
            BindingContext = PizzaObject;

        }

        private void Button_Add_Clicked(object sender, EventArgs e)
        {
            var T = (Button)sender;
            for(int i = 0; i < PizzaObject.Pizzas.Count; i++)
            {
                if(T.CommandParameter.ToString() == PizzaObject.Pizzas[i].Name)
                {
                    PizzaObject.Order.Add(PizzaObject.Pizzas[i]);
                    PizzaObject.Order_TotalNumberOfPizzas = PizzaObject.order_NumberInCart();
                    PizzaObject.Order_TotalAmount = PizzaObject.order_Calculate();
                    break;
                }
            }
        }

        private void Button_Delete_Clicked(object sender, EventArgs e)
        {
            var T = (Button)sender;
            for (int i = 0; i < PizzaObject.Order.Count; i++)
            {
                if (T.CommandParameter.ToString() == PizzaObject.Order[i].Name)
                {
                    PizzaObject.Order.Remove(PizzaObject.Order[i]);
                    PizzaObject.Order_TotalNumberOfPizzas = PizzaObject.order_NumberInCart();
                    PizzaObject.Order_TotalAmount = PizzaObject.order_Calculate();
                    break;
                }
            }
        }

        private void Button_Pay_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hello", PizzaObject.order_Calculate().ToString(), "ok");
        }
    }
}
