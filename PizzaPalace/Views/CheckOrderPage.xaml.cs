using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PizzaPalace.ViewModels;
using PizzaPalace.Models;

namespace PizzaPalace
{

    [DesignTimeVisible(false)]
    public partial class CheckOrderPage : ContentPage
    {
        private CheckOrderModel OrderModel;
        public CheckOrderPage()
        {
            InitializeComponent();
            OrderModel = new CheckOrderModel();
            BindingContext = OrderModel;
        }

        private async void Button_Checked(object sender, EventArgs e)
        {
            if((Entry_OrderNumber.Text == "ADMIN")&&(Entry_Password.Text == "ADMIN"))
            {
                await Navigation.PushAsync(new AdminLoginPage());
            }
            else
            {
                OrderItems Order = OrderModel.API_Order(Entry_OrderNumber.Text);
                if(Order.Items == "")
                {
                    await DisplayAlert("Error", "Invalid phonenumber", "OK");
                }
                else
                {
                    await DisplayAlert("Order #" + Order.Order_ID.ToString(), "Your pizzas(" + Order.Items + ") are " + OrderModel.API_OrderIsDone(Order.Order_ID), "OK");
                }
            }


        }
    }
}
