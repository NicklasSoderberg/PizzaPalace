using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PizzaPalace.Models
{
    class Constants
    {
        public Constants()
        {

        }

        public string getBaseURL()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return "http://192.168.1.216:45457/PizzaAPI/api";
                case Device.Android:
                    return "http://10.0.2.2/api";
                case Device.UWP:
                    return "http://127.0.0.2/api";
            }
            return "http://localhost/api";
        }
    }
}
