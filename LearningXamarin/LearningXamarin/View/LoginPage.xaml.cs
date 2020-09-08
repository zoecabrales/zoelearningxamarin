using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionAndBuildNumber;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            lblClickFunc();
            LblClickFunc2();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entLogin.Text) || string.IsNullOrEmpty(entPass.Text))
            {
                await DisplayAlert("Oops!", "Empty Credentials", "OK");
                return;
            }

            string login = entLogin.Text.ToLower();
            string password = entPass.Text;

            if (login == "qwer" && password == "1234")
            {
                await Navigation.PushAsync(new LoginSuccessPage());
                return;
            }
            else
            {
                await DisplayAlert("Oops!", "Entered Wrong Credentials", "OK");
            }
        }
        void LblClickFunc2()
        {
            LblClick2.GestureRecognizers.Add(new TapGestureRecognizer() 
            {
                Command = new Command (() =>
                {
                    Launcher.OpenAsync("https://facebook.com");
                })
        });
            
        }
        private void lblClickFunc()
        {
            lblClick.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command (() =>
                {
                    DisplayAlert("Hello There!", "Feature is still in progress. Sorry for the inconvenience.", "OK");
                })
            });
        }
    }
}