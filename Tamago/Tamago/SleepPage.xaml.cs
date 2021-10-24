using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamago
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SleepPage : ContentPage
    {
        public MainPage mainPage = new MainPage();

        public bool asleep = false;
        public SleepPage()
        {
            asleep = false;
            InitializeComponent();
            StartCountdown();
            ShowTired();
        }

        public async void StartCountdown()
        {
            if(!asleep) await Task.Delay(5000);
            asleep = true;
            await Task.Delay(1000);
            mainPage.AddTired();
            ShowTired();
            StartCountdown();
        }

        public void ShowTired()
        {
            float newTired = mainPage.GetTired();
            currentTired.Text = "current tiredness: " + newTired.ToString();
            tiredBar.Progress = newTired;
        }
    }
}