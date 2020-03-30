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

                OrderInfo temp = new OrderInfo();
                temp.FirstName = Entry_FirstName.Text;
                temp.LastName = Entry_LastName.Text;
                temp.Mail = Entry_Mail.Text;
                temp.Phone = Entry_Phone.Text;
                temp.Status = "in the oven";
                temp.Address = Entry_Address.Text;
                temp.Amount = OrderModel.Order_TotalAmount;
                temp.OrderTime = System.DateTime.Now;

                OrderModel.API_MakeOrder(temp);

                await DisplayAlert("Order received", "We have received your order", "OK");
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
