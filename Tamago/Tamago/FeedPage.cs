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
    public partial class FeedPage : ContentPage
    {
        uint moveSpeed = 500;
        public MainPage mainPage;

        public FeedPage(MainPage newMainPage)
        {
            mainPage = newMainPage;
            InitializeComponent();
            MoveButton();
            ShowHunger();
            BindingContext = this;
        }

        public void Button_GiveFood(object sender, System.EventArgs e)
        {
            mainPage.AddHunger();
            DisableButton();
            ShowHunger();
        }

        public async Task DisableButton()
        {
            feedingbutton.IsEnabled = false;
            feedingbutton.BorderColor = Color.Black;
            await Task.Delay(1000);
            feedingbutton.IsEnabled = true;
            feedingbutton.BorderColor = Color.White;
        }

        public async void MoveButton()
        {
            Random random = new Random();
            int x = random.Next(-100, 100);
            int y = random.Next(0, 400);
            await feedingbutton.TranslateTo(x, y, moveSpeed, Easing.Linear);
            MoveButton();
        }

        public void ShowHunger()
        {
            float newHunger = mainPage.GetHunger();
            currentHunger.Text = "current hunger: " + newHunger.ToString();
            hungryBar.Progress = newHunger;
        }
    }
}