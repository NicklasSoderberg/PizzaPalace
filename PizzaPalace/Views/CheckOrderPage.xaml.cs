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
            if(Entry_OrderNumber.Text == "ADMIN")
            {
                await Navigation.PushAsync(new AdminLoginPage());
            }
            else
            {
                //check via API
            }


        }
    }
}
