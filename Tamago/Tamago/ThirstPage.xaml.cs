using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamago
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirstPage : ContentPage
    {
        public bool canType;
        public string playerPW;
        public string password;


        public MainPage mainPage = new MainPage();
        public ThirstPage()
        {
            InitializeComponent();
            StartGame();
            ShowThirst();
        }

        public async void StartGame()
        {
            canType = false;
            newNumber.Text = "";
            Random random = new Random();
            int four = random.Next(1, 9);
            int three = random.Next(1, 9);
            int two = random.Next(1, 9);
            int one = random.Next(1, 9);
            await Task.Delay(2000);

            newNumber.Text = one.ToString();
            await Task.Delay(100);
            newNumber.Text = "";
            await Task.Delay(1000);
            newNumber.Text = two.ToString();
            await Task.Delay(100);
            newNumber.Text = "";
            await Task.Delay(1000);
            newNumber.Text = three.ToString();
            await Task.Delay(100);
            newNumber.Text = "";
            await Task.Delay(1000);
            newNumber.Text = four.ToString();
            await Task.Delay(100);
            newNumber.Text = "";
            password = one.ToString() + two.ToString() + three.ToString() + four.ToString();
            canType = true;
        }

        public void ResetPW(object sender, System.EventArgs e)
        {
            playerPW = "";
            newNumber.Text = playerPW;
        }

        public void CallGameStart(object sender, System.EventArgs e)
        {
            StartGame();
        }

        public void EnterPW(object sender, System.EventArgs e)
        {
            canType = false;
            if (playerPW == password)
            {
                newNumber.Text = "THIRST RESTORED!";
                mainPage.AddThirst();
                ShowThirst();
            }
            else
            {
                newNumber.Text = "PASSWORD DENIED";
            }
        }

        public void ShowThirst()
        {
            float newThirst = mainPage.GetThirst();
            currentThirst.Text = "current thirst: " + newThirst.ToString();
        }
        public void Button_1(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "1";
                newNumber.Text = playerPW;
            }
        }

        public void Button_2(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "2";
                newNumber.Text = playerPW;
            }
        }

        public void Button_3(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "3";
                newNumber.Text = playerPW;
            }
        }

        public void Button_4(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "4";
                newNumber.Text = playerPW;
            }
        }

        public void Button_5(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "5";
                newNumber.Text = playerPW;
            }
        }

        public void Button_6(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "6";
                newNumber.Text = playerPW;
            }
        }

        public void Button_7(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "7";
                newNumber.Text = playerPW;
            }
        }

        public void Button_8(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "8";
                newNumber.Text = playerPW;
            }
        }

        public void Button_9(object sender, System.EventArgs e)
        {
            if (canType)
            {
                playerPW = playerPW + "9";
                newNumber.Text = playerPW;
            }
        }
    }
}