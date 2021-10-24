using System.Threading;
using Xamarin.Forms;
using System.Timers;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;


namespace Tamago
{
    public partial class MainPage : ContentPage
    {
        public MainPage mainPage;
        public Creature MyCreature { get; set; } = new Creature
        {
            Name = "Creature",
            Hunger = .0f,
            Annoyed = .0f,
            Boredom = .0f,
            Tired = .0f,
            Lonely = .0f,
            Thirst = .0f,
            Overall = .0f
        };

        public MainPage()
        {
            mainPage = this;
            OnStartup();
            QuickFix();
            BindingContext = this;

            InitializeComponent();

            var timer = new System.Timers.Timer
            {
                Interval = 1000 * 120,
                AutoReset = true
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        } 

        private async void OnStartup()
        {
            var creatureDataStore = DependencyService.Get<Interface1<Creature>>();
            MyCreature = await creatureDataStore.ReadItem();
            if (MyCreature == null)
            {
                MyCreature = new Creature { Name = "newCreature" };
                await creatureDataStore.CreateItem(MyCreature);
            }

            await creatureDataStore.UpdateItem(MyCreature);
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MyCreature.Hunger += 0.1f;
            MyCreature.Annoyed += 0.4f;
            MyCreature.Boredom += 0.1f;
            MyCreature.Tired += 0.1f;
            MyCreature.Lonely += 0.1f;
            MyCreature.Thirst += 0.1f;

            MyCreature.Overall = MyCreature.Hunger + MyCreature.Annoyed + MyCreature.Boredom + MyCreature.Tired + MyCreature.Lonely + MyCreature.Thirst;

            UpdateCreature();
        }

        public async void QuickFix()
        {
            await Task.Delay(1000);
            UpdateCreature();
        }

        public void UpdateCreature()
        {
            if (MyCreature.Hunger >= 1f) MyCreature.Hunger = 1f;
            if (MyCreature.Thirst >= 1f) MyCreature.Thirst = 1f;
            if (MyCreature.Boredom >= 1f) MyCreature.Boredom = 1f;
            if (MyCreature.Lonely >= 1f) MyCreature.Lonely = 1f;
            if (MyCreature.Annoyed >= 1f) MyCreature.Annoyed = 1f;
            if (MyCreature.Tired >= 1f) MyCreature.Tired = 1f;

            if (MyCreature.Hunger <= .0f) MyCreature.Hunger = 0f;
            if (MyCreature.Thirst <= .0f) MyCreature.Thirst = 0f;
            if (MyCreature.Boredom <= .0f) MyCreature.Boredom = 0f;
            if (MyCreature.Lonely <= .0f) MyCreature.Lonely = 0f;
            if (MyCreature.Annoyed <= .0f) MyCreature.Annoyed = 0f;
            if (MyCreature.Tired <= .0f) MyCreature.Tired = 0f;

            var creatureDataStore = DependencyService.Get<Interface1<Creature>>();
            creatureDataStore.UpdateItem(MyCreature);

            hungryBar.Progress = MyCreature.Hunger;
            thirstyBar.Progress = MyCreature.Thirst;
            thirstyBar.Progress = MyCreature.Thirst;
            boredomBar.Progress = MyCreature.Boredom;
            lonelyBar.Progress = MyCreature.Lonely;
            annoyedBar.Progress = MyCreature.Annoyed;
            tiredBar.Progress = MyCreature.Tired;

            overallBar.Progress = MyCreature.Overall / 6f;

            hungryBar.ProgressColor = MyCreature.Hunger >= 0.5f ? Color.Red : Color.LightGreen;

            thirstyBar.ProgressColor = MyCreature.Thirst >= 0.5f ? Color.Red : Color.LightGreen;

            boredomBar.ProgressColor = MyCreature.Boredom >= 0.5f ? Color.Red : Color.LightGreen;

            lonelyBar.ProgressColor = MyCreature.Lonely >= 0.5f ? Color.Red : Color.LightGreen;

            annoyedBar.ProgressColor = MyCreature.Annoyed >= 0.5f ? Color.Red : Color.LightGreen;

            tiredBar.ProgressColor = MyCreature.Tired >= 0.5f ? Color.Red : Color.LightGreen;

            if(MyCreature.HungerText != "no action required")
            {
                hungerC.TextColor = Color.Red;
            }
            else
            {
                hungerC.TextColor = Color.LightGreen;
            }

            if(MyCreature.ThirstText != "no action required")
            {
                thirstC.TextColor = Color.Red;
            }
            else
            {
                thirstC.TextColor = Color.LightGreen;
            }

            if(MyCreature.BoredomText != "no action required")
            {
                boredC.TextColor = Color.Red;
            }
            else
            {
                boredC.TextColor = Color.LightGreen;
            }

            if(MyCreature.AnnoyedText != "no action required")
            {
                annoyedC.TextColor = Color.Red;
            }
            else
            {
                annoyedC.TextColor = Color.LightGreen;
            }

            if(MyCreature.TiredText != "no action required")
            {
                tiredC.TextColor = Color.Red;
            }
            else
            {
                tiredC.TextColor = Color.LightGreen;
            }

            if(MyCreature.LonelyText != "no action required")
            {
                lonelyC.TextColor = Color.Red;
            }
            else
            {
                lonelyC.TextColor = Color.LightGreen;
            }
        }

        void Button_Feed(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FeedPage(mainPage));
        }

        void Button_GiveDrink(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ThirstPage(mainPage));
        }

        void Button_Entertain(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new BoredomPage(mainPage));
        }

        void Button_Lonely(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LonelyPage(mainPage));
        }

        void Button_Annoyed(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AnnoyedPage());
        }

        void Button_Sleep(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SleepPage(mainPage)); 
        }

        public void AddHunger()
        {
            MyCreature.Hunger -= 0.1f;
            UpdateCreature();
        }

        public void AddThirst()
        {
            MyCreature.Thirst = 0f;
            UpdateCreature();
        }

        public void AddBoredom()
        {
            MyCreature.Boredom -= 0.1f;
            UpdateCreature();
        }

        public void AddLonely()
        {
            MyCreature.Lonely -= 0.1f;
            UpdateCreature();
        }

        public void AddTired()
        {
            MyCreature.Tired -= 0.1f;
            UpdateCreature();
        }

        public float GetHunger()
        {
            float currentHunger = MyCreature.Hunger;
            hungryBar.Progress = MyCreature.Hunger;
            return currentHunger;
        }

        public float GetThirst()
        {
            float currentThirst = MyCreature.Thirst;
            return currentThirst;
        }

        public float GetLonely()
        {
            float currentLonely = MyCreature.Lonely;
            return currentLonely;
        }

        public float GetBoredom()
        {
            float currentBoredom = MyCreature.Boredom;
            return currentBoredom;
        }

        public float GetTired()
        {
            float currentTired = MyCreature.Tired;
            return currentTired;
        }
    }
}