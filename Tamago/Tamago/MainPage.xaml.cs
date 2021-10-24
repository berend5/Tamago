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
        public Creature MyCreature { get; set; } = new Creature
        {
            Name = "Creature",
            Hunger = .0f,
            Annoyed = .0f,
            Boredom = .0f,
            Tired = .0f,
            Lonely = .0f,
            Thirst = .0f
        };

        public MainPage()
        {
            OnStartup();
            BindingContext = this;

            InitializeComponent();

            var timer = new System.Timers.Timer
            {
                Interval = 50 * 60,
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

            hungryText.Text = MyCreature.HungerText; //wip, kijken of ik iets anders dan binding kan gebruiken
            hungryBar.Progress = MyCreature.Hunger;

            thirstyText.Text = MyCreature.ThirstText;
            thirstyBar.Progress = MyCreature.Thirst;

            thirstyBar.Progress = MyCreature.Thirst;
            boredomBar.Progress = MyCreature.Boredom;
            lonelyBar.Progress = MyCreature.Lonely;
            annoyedBar.Progress = MyCreature.Annoyed;
            tiredBar.Progress = MyCreature.Tired;

            if (MyCreature.Hunger >= 0.5f)
            {
                hungryBar.ProgressColor = Color.Red;
            }
            else
            {
                hungryBar.ProgressColor = Color.LightGreen;
            }

            if (MyCreature.Thirst >= 0.5f)
            {
                thirstyBar.ProgressColor = Color.Red;
            }
            else
            {
                thirstyBar.ProgressColor = Color.LightGreen;
            }

            if (MyCreature.Boredom >= 0.5f)
            {
                boredomBar.ProgressColor = Color.Red;
            }
            else
            {
                boredomBar.ProgressColor = Color.LightGreen;
            }

            if (MyCreature.Lonely >= 0.5f)
            {
                lonelyBar.ProgressColor = Color.Red;
            }
            else
            {
                lonelyBar.ProgressColor = Color.LightGreen;
            }

            if (MyCreature.Annoyed >= 0.5f)
            {
                annoyedBar.ProgressColor = Color.Red;
            }
            else
            {
                annoyedBar.ProgressColor = Color.LightGreen;
            }

            if (MyCreature.Tired >= 0.5f)
            {
                tiredBar.ProgressColor = Color.Red;
            }
            else
            {
                tiredBar.ProgressColor = Color.LightGreen;
            }
        }

        void Button_Feed(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FeedPage());
        }

        void Button_GiveDrink(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ThirstPage());
        }

        void Button_Entertain(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new BoredomPage());
        }

        void Button_Lonely(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LonelyPage());
        }

        void Button_Annoyed(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AnnoyedPage());
        }

        void Button_Sleep(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SleepPage()); 
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
            hungryText.Text = MyCreature.HungerText;
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