using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningXamarin
{
    public partial class App : Application
    {
        public static object Application { get; internal set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Page1());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
