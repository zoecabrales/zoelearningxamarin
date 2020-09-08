using System;
using VersionAndBuildNumber.DependencyServices;
using Xamarin.Forms;
namespace VersionAndBuildNumber
{
    public partial class VersionAndBuildNumberPage : ContentPage
    {
        public VersionAndBuildNumberPage()
        {
            InitializeComponent();
            lblVersionNumber.Text = DependencyService.Get<IAppVersionAndBuild>().GetVersionNumber();
            lblBuildNumber.Text = DependencyService.Get<IAppVersionAndBuild>().GetBuildNumber();
        }
    }
}