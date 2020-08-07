using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(XamarinStudy.Droid.Effects.EntryAndroidEffect), nameof(LearningXamarin.Effects.EntryEffect))]

    namespace XamarinStudy.Droid.Effects
{
    public class EntryAndroidEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}
    
