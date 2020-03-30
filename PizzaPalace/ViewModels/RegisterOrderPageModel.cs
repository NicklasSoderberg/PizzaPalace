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
using System.Net.Http.Headers;

namespace PizzaPalace.ViewModels
{
    class RegisterOrderPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public RegisterOrderPageModel(List<Models.MenuItem> TOrderList)
        {
            OrderList = TOrderList;
            order_TotalAmount = order_Calculate();
        }

        List<Models.MenuItem> OrderList { get; set; }

        public int order_TotalAmount = 0;
        public int Order_TotalAmount
        {
            get => order_TotalAmount;
            set
            {
                order_TotalAmount = value;
                OnPropertyChanged(nameof(Order_TotalAmount));
            }
        }

        public string input_FirstName = "";
        public string Input_FirstName
        {
            get => input_FirstName;
            set
            {
                input_FirstName = value;
                OnPropertyChanged(nameof(Input_FirstName));
            }
        }

        public string input_LastName = "";
        public string Input_LastName
        {
            get => input_LastName;
            set
            {
                input_LastName = value;
                OnPropertyChanged(nameof(Input_LastName));
            }
        }

        public string input_Mail = "";
        public string Input_Mail
        {
            get => input_Mail;
            set
            {
                input_Mail = value;
                OnPropertyChanged(nameof(Input_Mail));
            }
        }

        public string input_Address = "";
        public string Input_Address
        {
            get => input_Address;
            set
            {
                input_Address = value;
                OnPropertyChanged(nameof(Input_Address));
            }
        }

        public string input_Phone = "";
        public string Input_Phone
        {
            get => input_Phone;
            set
            {
                input_Phone = value;
                OnPropertyChanged(nameof(Input_Phone));
            }
        }

        public int order_Calculate()
        {
            int tCalc = 0;
            for(int i = 0; i < OrderList.Count; i++)
            {
                tCalc = tCalc + OrderList[i].Price;
            }
            return tCalc;
        }

        public int order_NumberInCart()
        {
            return OrderList.Count;
        }

        public bool InputCorrect()
        {
            if((Input_FirstName == "") ||
               (Input_LastName == "") ||
                (Input_Mail == "") ||
                (Input_Phone == "") ||
                    (!Input_Mail.Contains("@")))
            {
                return false;    
            }
           
            return true;  
        }

        public Entry ChangeEntry(Entry tEntry, bool mailCheck)
        {
            if (tEntry.Text == "")
            {
                tEntry.BackgroundColor = Color.Red;
            }
            else
            {
                tEntry.BackgroundColor = Color.Beige;
            }
            if ((mailCheck) && (!tEntry.Text.Contains("@")))
            {
                tEntry.BackgroundColor = Color.Red;
            }

            return tEntry;
        }

        public void API_MakeOrder(OrderInfo Info)
        {
            Constants BaseURL = new Constants();
            string URL = BaseURL.getBaseURL() + "/order";
            try
            {
                CompleteOrder Order = new CompleteOrder();
                Order.NewOrderInfo = Info;
                Order.OrderList = new List<OrderInfoItem>();

                for (int i = 0; i < OrderList.Count(); i++)
                {
                    Order.OrderList.Add(new OrderInfoItem { ID_Item = OrderList[i].ID, ID_OrderInfo = 0});
                }

                var myContent = JsonConvert.SerializeObject(Order);
                HttpContent c = new StringContent(myContent, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                var result = client.PostAsync(new Uri(URL), c);

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

    }
}
