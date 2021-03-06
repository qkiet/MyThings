﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using MyThings.Data_Model;


namespace MyThings
{
    [DesignTimeVisible(false)]
    

    

    public partial class Page1 : ContentPage
    {
        public List<UserProfile> myprofile;
        public Page1(List<UserProfile> profile)
        {

            InitializeComponent();
            myprofile = profile;
            foreach (UserProfile element in profile)
            {
                channel_picker.Items.Add(element.name);
            }
            //Set bindind
            
            
        }



        async Task<ChannelFeed> ReallyGetData(string id, string api, CancellationToken ct)
        {
            RESTService api_client = new RESTService();
            string channel_feeds = await api_client.Get("https://api.thingspeak.com/channels/" + id + "/feeds.json?timezone=Asia%2FBangkok&api_key=" + api + "&results=2", ct);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            ChannelFeed feeds_json = JsonConvert.DeserializeObject<ChannelFeed>(channel_feeds, settings);
            return feeds_json;
            //temperature.Text = feeds_json.feeds[1].field1;
            //pH.Text = feeds_json.feeds[1].field2;
            //update_time.Text = feeds_json.feeds[1].created_at.ToString("dd/MM/yyyy HH:mm tt");

        }

        Thread scheduleThread;

        async void Handle_picker(object sender, EventArgs e)
        {
            int current_index = channel_picker.SelectedIndex;
            if (scheduleThread != null)
                return;
            else
                scheduleThread = Thread.CurrentThread;
            CancellationTokenSource cts;
            while (true)
            {
                cts = new CancellationTokenSource();

                //Check internet connection
                //var connect_status = Connectivity.NetworkAccess;
                //if (connect_status == NetworkAccess.Internet)
                //{
                    //status_text.TextColor = Color.Green;
                    //status_text.Text = "Đang theo dõi";
                if (channel_picker.SelectedIndex != current_index)
                {
                    status_text.Text = "";
                    temperature_text.Text = "";
                    temperature.Text = "";
                    ph_text.Text = "";
                    pH.Text = "";
                    turb_text.Text = "";
                    turb.Text = "";
                    update_text.Text = "";
                    update_time.Text = "";
                    current_index = channel_picker.SelectedIndex;
                }
                channel_name.Text = myprofile[channel_picker.SelectedIndex].name;
                bool Is_Exception = false;
                try
                {
                    cts.CancelAfter(2300);
                    Task<ChannelFeed> theTask = ReallyGetData(myprofile[channel_picker.SelectedIndex].id.ToString(), myprofile[channel_picker.SelectedIndex].api_keys[1].api_key, cts.Token);
                    ChannelFeed myFeeds = await theTask;
                    status_text.TextColor = Color.Green;
                    status_text.Text = "Đang theo dõi";
                    temperature_text.Text = myFeeds.channel.field1 + ":";
                    temperature.Text = myFeeds.feeds[1].field1;
                    ph_text.Text = myFeeds.channel.field2 + ":";
                    pH.Text = myFeeds.feeds[1].field2;
                    turb_text.Text = myFeeds.channel.field3 + ":";
                    turb.Text = myFeeds.feeds[1].field3;
                    update_text.Text = "Cập nhật lần cuối vào:";
                    update_time.Text = myFeeds.feeds[1].created_at.ToString("dd/MM/yyyy HH:mm tt");
                }

                catch (Exception)
                {
                    Is_Exception = true;
                    status_text.TextColor = Color.Red;
                    status_text.Text = "Lỗi Internet";
                }

                // do something with time...
                //}
                cts = null;
                if (Is_Exception != true)
                    await Task.Delay(2300);
            }

        }
    }
}
