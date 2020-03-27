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
        public RegisterOrderPage()
        {
            InitializeComponent();
        }

        private async void Button_DeliverNow_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
