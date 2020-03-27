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
    public partial class OrderPage : ContentPage
    {
        private OrderPageModel PizzaObject;

        public OrderPage()
        {
            InitializeComponent();
            PizzaObject = new OrderPageModel();
            BindingContext = PizzaObject;
        }

        private void Button_Add_Clicked(object sender, EventArgs e)
        {
            var T = (Button)sender;
            for(int i = 0; i < PizzaObject.MenuItems.Count; i++)
            {
                if(T.CommandParameter.ToString() == PizzaObject.MenuItems[i].Name)
                {
                    PizzaObject.Order.Add(PizzaObject.MenuItems[i]);
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

        private async void Button_Delivery_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterOrderPage());
        }

        private async void Button_CheckOrders_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckOrderPage());
        }
    }
}
