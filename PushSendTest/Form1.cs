﻿using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PushSendTest
{
    public partial class Form1 : Form
    {
        public const string API_KEY = "AIzaSyChLMPZ8MKz6izwh2AdbQJHxZHQJlxbINo";
        public const string MESSAGE = "Hello, Xamarin!";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("message", MESSAGE);
            jGcmData.Add("to", "/topics/global");
            jGcmData.Add("data", jData);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + API_KEY);

                    Task.WaitAll(client.PostAsync(url,
                        new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
                            .ContinueWith(response =>
                            {
                                Console.WriteLine(response);
                                Console.WriteLine("Message sent: check the client device notification tray.");
                            }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to send GCM message:");
                Console.Error.WriteLine(ex.StackTrace);
            }
        }
    }
}
