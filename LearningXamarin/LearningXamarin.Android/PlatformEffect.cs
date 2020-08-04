namespace XamarinStudy.Droid.Effects
{
    public class PlatformEffect
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