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
    public partial class LonelyPage : ContentPage
    {
        public MainPage mainPage;
        private bool inPg;
        private bool isMoving;

        public LonelyPage(MainPage newMainPage)
        {
            mainPage = newMainPage;
            InitializeComponent();
            ShowLonely();
        }

        public void EnterPlayground(object sender, System.EventArgs e)
        {
            if (inPg) return;
            inPg = true;
            creatureImage.IsVisible = true;
            AddPoints();
            MoveCreature();
        }

        public void ExitPlayground(object sender, System.EventArgs e)
        {
            if (!inPg) return;
            inPg = false;
            creatureImage.IsVisible = false;
        }

        public async void MoveCreature()
        {
            if (isMoving) return;
            isMoving = true;
            Random random = new Random();
            int x = random.Next(-75, 75);
            int y = random.Next(0, 300);
            await creatureImage.TranslateTo(x, y, 2000, Easing.BounceOut);
            isMoving = false;
            MoveCreature();
        }

        public void ShowLonely()
        {
            float newLonely = mainPage.GetLonely();
            currentLoneliness.Text = "current loneliness: " + newLonely.ToString();
            lonelyBar.Progress = newLonely;
        }

        public async void AddPoints()
        {
            if (!inPg) return;
            await Task.Delay(1000);
            mainPage.AddLonely();
            ShowLonely();
            AddPoints();
        }
    }
}