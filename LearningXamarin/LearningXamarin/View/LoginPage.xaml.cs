using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VersionAndBuildNumber;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace LearningXamarin
{
    
    public partial class LoginPage : ContentPage
    {
        int _placeholderFontSize = 18;
        int _titleFontSize = 14;
        int _topMargin = -32;

        public event EventHandler Completed;

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null, HandleBindingPropertyChangedDelegate);

        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null);
        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(LoginPage), ReturnType.Default);
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create("IsPassword", typeof(bool), typeof(LoginPage), default(bool));
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(LoginPage), Keyboard.Default, coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);

        static async void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as LoginPage;
            if (!control.EntryField.IsFocused)
            {
                if (!string.IsNullOrEmpty((string)newValue))
                {
                    await control.TransitionToTitle(false);
                }
                else
                {
                    await control.TransitionToPlaceholder(false);
                }
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public new void Focus()
        {
            if (IsEnabled)
            {
                EntryField.Focus();
            }
        }

        async void Handle_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                await TransitionToTitle(true);
            }
        }

        async void Handle_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                await TransitionToPlaceholder(true);
            }
        }

        async Task TransitionToTitle(bool animated)
        {
            if (animated)
            {
                var t1 = LabelTitle.TranslateTo(0, _topMargin, 100);
                var t2 = SizeTo(_titleFontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                LabelTitle.TranslationX = 0;
                LabelTitle.TranslationY = -30;
                LabelTitle.FontSize = 14;
            }
        }

        async Task TransitionToPlaceholder(bool animated)
        {
            if (animated)
            {
                var t1 = LabelTitle.TranslateTo(10, 0, 100);
                var t2 = SizeTo(_placeholderFontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                LabelTitle.TranslationX = 10;
                LabelTitle.TranslationY = 0;
                LabelTitle.FontSize = _placeholderFontSize;
            }
        }

        void Handle_Tapped(object sender, EventArgs e)
        {
            if (IsEnabled)
            {
                EntryField.Focus();
            }
        }

        Task SizeTo(int fontSize)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            // setup information for animation
            Action<double> callback = input => { LabelTitle.FontSize = input; };
            double startingHeight = LabelTitle.FontSize;
            double endingHeight = fontSize;
            uint rate = 5;
            uint length = 100;
            Easing easing = Easing.Linear;

            // now start animation with all the setup information
            LabelTitle.Animate("invis", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        void Handle_Completed(object sender, EventArgs e)
        {
            Completed?.Invoke(this, e);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsEnabled))
            {
                EntryField.IsEnabled = IsEnabled;
            }
        }

        public LoginPage()
        {
            InitializeComponent();
            lblClickFunc();
            LblClickFunc2();
            NavigationPage.SetHasNavigationBar(this, false);
            LabelTitle.TranslationX = 10;
            LabelTitle.FontSize = _placeholderFontSize;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(EntryPassword.Text))
            {
                await DisplayAlert("Oops!", "Empty Credentials", "OK");
                return;
            }

            string login = EntryField.Text.ToLower();
            string password = EntryPassword.Text;

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
                Command = new Command(() =>
               {
                   Launcher.OpenAsync("https://facebook.com");
               })
            });

        }
        private void lblClickFunc()
        {
            lblClick.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
               {
                   DisplayAlert("Hello There!", "Feature is still in progress. Sorry for the inconvenience.", "OK");
               })
            });
        }
    }
}
