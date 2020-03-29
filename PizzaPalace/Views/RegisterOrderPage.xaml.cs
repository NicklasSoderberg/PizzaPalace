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
    public partial class RegisterOrderPage : ContentPage
    {
        private RegisterOrderPageModel OrderModel; 
        public RegisterOrderPage(List<Models.MenuItem> TOrderList)
        {
            InitializeComponent();
            OrderModel = new RegisterOrderPageModel(TOrderList);
            BindingContext = OrderModel;
        }

        private async void Button_DeliverNow_Clicked(object sender, EventArgs e)
        {
            if (OrderModel.InputCorrect())
            {
                MessagingCenter.Send<RegisterOrderPage>(this, "Clear");

                // Post API

                await Navigation.PopAsync();
            }
            else
            {
                Entry_FirstName = OrderModel.ChangeEntry(Entry_FirstName, false);
                Entry_LastName = OrderModel.ChangeEntry(Entry_LastName, false);
                Entry_Mail = OrderModel.ChangeEntry(Entry_Mail, true);
                Entry_Address = OrderModel.ChangeEntry(Entry_Address, false);
                Entry_Phone = OrderModel.ChangeEntry(Entry_Phone, false);
                await DisplayAlert("Invalid input", "Please check the delivery form", "OK");
            }
        }
    }
}
