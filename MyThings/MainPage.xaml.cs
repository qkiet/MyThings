using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Essentials;

using Newtonsoft.Json;
using MyThings.Data_Model;



namespace MyThings
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }




        async void Handle_Clicked(object sender, EventArgs e)
        {
            status.Text = "new page";
            await Navigation.PushAsync(new Page1(username_text.Text, pass_text.Text));


            //var connect = Connectivity.NetworkAccess;
            //CancellationTokenSource cts;
            //cts = new CancellationTokenSource();
            //status.Text = "";
            //if (connect == NetworkAccess.Internet) //There is connection
            //{
            //    try
            //    {
            //        cts.CancelAfter(2800);
            //        RESTService api_client = new RESTService();
            //        string user_profile = await api_client.Get("https://api.thingspeak.com/channels.json?api_key=" + username_text.Text);

            //        var settings = new JsonSerializerSettings
            //        {
            //            NullValueHandling = NullValueHandling.Ignore,
            //            MissingMemberHandling = MissingMemberHandling.Ignore
            //        };
            //        if (user_profile.Contains("Authorization Required"))
            //        {
            //            status.TextColor = Color.Red;
            //            status.Text = "Nhập sai User API Key! Vui lòng kiểm tra lại";
            //        }
            //        else
            //        {
            //            status.TextColor = Color.Green;
            //            status.Text = "Thành công!";
            //            username_text.Text = "";
            //            List<UserProfile> profile_json = JsonConvert.DeserializeObject<List<UserProfile>>(user_profile, settings);
            //            await Navigation.PushAsync(new Page1(profile_json));
            //        }

            //    }
            //    catch (Exception)
            //    {
            //        status.TextColor = Color.Red;
            //        status.Text = "Không kết nối với Internet!";
            //    }


            //}
            //else
            //{
            //    status.TextColor = Color.Red;
            //    status.Text = "Không kết nối với Internet!";
            //}



        }


    }

}
