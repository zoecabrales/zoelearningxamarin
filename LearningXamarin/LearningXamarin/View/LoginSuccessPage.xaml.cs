﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginSuccessPage : ContentPage
    {
        public ObservableCollection<Category> Categories { get; set; }
        public LoginSuccessPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            Categories = new ObservableCollection<Category>();
            Categories.Add(new Category("SPORT"));
            Categories.Add(new Category("LIFESTYLE"));
            Categories.Add(new Category("NIKE"));

            BindingContext = this;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
            return;
        }
    }

    public class Category
    {
        public string Title { get; set; }

        public Category(string title)
        {
            Title = title;
        }
    }
}