using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Xamarin.Forms;

namespace App.Template.XForms.Android
{
    [Activity(Label = "App.Template",
        MainLauncher = true,
        Icon = "@mipmap/ic_launcher",
        Theme = "@style/Theme.Splash",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // Leverage controls' StyleId attrib. to Xamarin.UITest
            Forms.ViewInitialized += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                    e.NativeView.ContentDescription = e.View.StyleId;
            };
            base.OnCreate(bundle);
        }

        protected override void RunAppStart(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
        }

        protected override void TriggerFirstNavigate()
        {
            //base.TriggerFirstNavigate();
        }
    }
}