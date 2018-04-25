using Android.Content;
using App.Template.XForms.Core;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using Xamarin.Forms;

namespace App.Template.XForms.Android
{
    public class Setup : MvxFormsAndroidSetup<Core.App, FormsApp>
    {
        #region Methods

        protected override IMvxAndroidViewsContainer CreateViewsContainer(Context applicationContext)
        {
            var viewsContainer =
                ((FormsApp) Application.Current).LoadViewsContainer(new MvxAndroidViewsContainer(applicationContext));
            return (IMvxAndroidViewsContainer) viewsContainer;
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Core.App.LoadServiceLocator();
        }

        #endregion
    }
}