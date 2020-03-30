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
    public partial class AdminLoginPage : ContentPage
    {
        private AdminLoginModel AdminModel;
        public AdminLoginPage()
        {
            InitializeComponent();
            AdminModel = new AdminLoginModel();
            BindingContext = AdminModel;
        }

        private void Button_Done_Clicked(object sender, EventArgs e)
        {
            var T = (Button)sender;
            for(int i = 0; i < AdminModel.UnDoneOrders.Count(); i++)
            {
                if(T.CommandParameter.ToString() == AdminModel.UnDoneOrders[i].ID.ToString())
                {
                    AdminModel.API_ChangeOrder(AdminModel.UnDoneOrders[i].ID);
                    AdminModel.UnDoneOrders.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
