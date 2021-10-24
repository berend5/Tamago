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
    public partial class BoredomPage : ContentPage
    {
        public MainPage mainPage = new MainPage();
        public BoredomPage()
        {
            InitializeComponent();
            StartTimer();
            ShowBoredom();
        }

        public async Task StartTimer()
        {
            await gameButton.TranslateTo(-400, 0, 380, Easing.Linear);
            Random random = new Random();
            int waitTime1 = random.Next(1000, 4000);
            await Task.Delay(waitTime1);
            await gameButton.TranslateTo(400, 0, 380, Easing.Linear);
            int waitTime2 = random.Next(1000, 4000);
            await Task.Delay(waitTime2);
            StartTimer();
        }

        void Button_Pressed(object sender, System.EventArgs e)
        {
            mainPage.AddBoredom();
            ShowBoredom();
        }

        public void ShowBoredom()
        {
            float newBoredom = mainPage.GetBoredom();
            currentBoredom.Text = "current boredom: " + newBoredom.ToString();
            boredomBar.Progress = newBoredom;
        }
    }
}