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
    class CheckOrderModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string input_OrderNumber = "";
        public string Input_OrderNumber
        {
            get => input_OrderNumber;
            set
            {
                input_OrderNumber = value;
                Input_Password_Visable = (input_OrderNumber == "ADMIN");
                OnPropertyChanged(nameof(Input_OrderNumber));
                OnPropertyChanged(nameof(Input_Password_Visable));
            }
        }

        public string input_Password = "";
        public string Input_Password
        {
            get => input_Password;
            set
            {
                input_Password = value;
                OnPropertyChanged(nameof(Input_Password));
            }
        }

        public bool input_Password_Visable = false;
        public bool Input_Password_Visable
        {
            get => input_Password_Visable;
            set
            {
                input_Password_Visable = value;
                OnPropertyChanged(nameof(Input_Password_Visable));
            }
        }

    }
}
