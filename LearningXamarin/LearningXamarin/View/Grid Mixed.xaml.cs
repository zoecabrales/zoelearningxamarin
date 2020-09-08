using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
        static int BtnCount = 0;
        public Page5()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (BtnCount < 1)
            {
                label.Text = "Xamarin.Forms is an open source cross-platform framework from Microsoft for building iOS, Android, & Windows apps with .NET from a single shared codebase.";
                BtnCount++;
            }
            else
            {

                label.Text = "I am a Xamarin Developer";
                BtnCount = 0;

            }
        }
    }
}