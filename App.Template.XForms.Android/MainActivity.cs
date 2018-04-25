using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using Xamarin.Forms;

namespace App.Template.XForms.Android
{
    [Activity(Label = "App Template", MainLauncher = false, Icon = "@mipmap/ic_launcher", Theme = "@style/AppTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTop)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabbar;
            ToolbarResource = Resource.Layout.toolbar;
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Forms.Init(this, bundle);
            base.OnCreate(bundle);
        }
    }
}