using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Droid;
using MvvmCross.Forms.Droid.Presenters;
using MvvmCross.Platform;
using Xamarin.Forms;

namespace App.Template.XForms.Android
{
    [Activity(Label = "App Template", MainLauncher = false, Icon = "@mipmap/ic_launcher", Theme = "@style/AppTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTop)]
    public class MasterDetailApplicationActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            TabLayoutResource = Resource.Layout.tabbar;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);


            var mvxFormsApp = new MvxFormsApplication();
            LoadApplication(mvxFormsApp);
            //var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidPagePresenter;
            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidMasterDetailPagePresenter;
            if (presenter != null) presenter.MvxFormsApp = mvxFormsApp;

            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}