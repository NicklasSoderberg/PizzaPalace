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
        public CheckOrderPage()
        {
            InitializeComponent();
            //PizzaObject = new OrderPageModel();
            //BindingContext = PizzaObject;
        }
    }
}
