﻿using PizzaPalace.Models;
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
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

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

        public OrderItems API_Order(string PhoneNumber)
        {
            Constants BaseURL = new Constants();
            string URL = BaseURL.getBaseURL() + "/order?PhoneNumber=" + PhoneNumber;
            try
            {
                var client = new HttpClient();
                var response = client.GetStringAsync(URL).Result;
                OrderItems returnThis;
                returnThis = JsonConvert.DeserializeObject<OrderItems>(response);
                return returnThis;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return null;
        }

        public string API_OrderIsDone(int OrderID)
        {
            Constants BaseURL = new Constants();
            string URL = BaseURL.getBaseURL() + "/order?OrderID=" + OrderID.ToString();
            try
            {
                var client = new HttpClient();
                var response = client.GetStringAsync(URL).Result;
                
                return JsonConvert.DeserializeObject<string>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return null;
        }

    }
}
