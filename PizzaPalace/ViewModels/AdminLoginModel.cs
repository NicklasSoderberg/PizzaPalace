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
    class AdminLoginModel : INotifyPropertyChanged
    {
        public AdminLoginModel()
        {
            UnDoneOrders = API_GetUnDone();
            ObservableCollection<GetUnDoneOrders> temp = new ObservableCollection<GetUnDoneOrders>();
            int curID = -1;
            int curIndex = -1;
            for (int i = 0; i < UnDoneOrders.Count(); i++)
            {
                if(curID != UnDoneOrders[i].ID)
                {
                    curID = UnDoneOrders[i].ID;
                    curIndex++;
                    temp.Add(UnDoneOrders[i]);
                    temp[curIndex].Name = "";
                }

                if (temp[curIndex].Name.Length > 0)
                {
                    temp[curIndex].Name += ", " + UnDoneOrders[i].Name;
                }
                else
                {
                    temp[curIndex].Name += UnDoneOrders[i].Name;
                }
            }
            
            UnDoneOrders = temp;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<GetUnDoneOrders> UnDoneOrders { get; set; }

        public ObservableCollection<GetUnDoneOrders> API_GetUnDone()
        {
            Constants BaseURL = new Constants();
            string URL = BaseURL.getBaseURL() + "/admin";
            try
            {
                var client = new HttpClient();
                var response = client.GetStringAsync(URL).Result;

                ObservableCollection<GetUnDoneOrders> temp = JsonConvert.DeserializeObject<ObservableCollection<GetUnDoneOrders>>(response);
                for (int i = 0; i < temp.Count(); i++)
                {
                    temp[i].Address.Trim();
                    temp[i].Name.Trim();
                    temp[i].Phone.Trim();
                    temp[i].OrderTime.ToString("de-DE");
                }

                return temp;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return null;
        }

        public void API_ChangeOrder(int id)
        {
            Constants BaseURL = new Constants();
            string URL = BaseURL.getBaseURL() + "/admin";
            try
            {
                var myContent = JsonConvert.SerializeObject(id);
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
