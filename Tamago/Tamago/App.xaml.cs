using Xamarin.Forms;
using System;
using Xamarin.Essentials;

namespace Tamago
{
    public partial class App : Application
    {
        TimeSpan timeAsleep;
        public Creature creature = new Creature();
        public App()
        {
            DependencyService.RegisterSingleton<Interface1<Creature>>(new LocalCreatureStore());

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.Now);
            var wakeTime = DateTime.Now;

            timeAsleep = wakeTime - sleepTime;
            float hours = Convert.ToSingle(timeAsleep.TotalHours);
            creature.DecreaseStatsFromSleeptime(hours);
        }

        protected override void OnSleep()
        {
            var sleepTime = DateTime.Now;
            Preferences.Set("SleepTime", sleepTime);
        }

        protected override void OnResume()
        {
            
        }
    }
}
