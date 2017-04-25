using System;
using Xamarin.Forms;

namespace PushGoogle
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string message)
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(message))
            {
                this.lblTextMessage.Text = string.Concat("Welcome to Xamarin: ", message);
            }
            else
            {
                this.lblTextMessage.Text = "Welcome to Xamarin Forms SEM MESSAGE!";
            }
        }
    }
}
