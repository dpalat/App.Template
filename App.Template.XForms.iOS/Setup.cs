using App.Template.XForms.Core;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Views;

namespace App.Template.XForms.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, FormsApp>
    {
        protected override IMvxIosViewsContainer CreateIosViewsContainer()
        {
            var viewsContainer =
                ((FormsApp) Xamarin.Forms.Application.Current).LoadViewsContainer(
                    new MvxIosViewsContainer());
            return (IMvxIosViewsContainer) viewsContainer;
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Core.App.LoadServiceLocator();
        }

       //protected override void InitializeBindingBuilder()
       // {
       //     var bindingBuilder = CreateBindingBuilder();

       //     RegisterBindingBuilderCallbacks();
       //     bindingBuilder.DoRegistration();
       // }


        //protected override MvxBindingBuilder CreateBindingBuilder()
        //{
        //    return new MvxFormsIosBindingBuilder();
        //}


        //private void SubscribeToAppLifeCicleEvents()
        //{
        //    FormsApplication.Start += (s, e) =>
        //    {
        //        Mvx.Resolve<IMvxMessenger>().Publish(new AppStartMessage(FormsApplication));
        //    };
        //    FormsApplication.Sleep += (s, e) =>
        //    {
        //        Mvx.Resolve<IMvxMessenger>().Publish(new AppSleepMessage(FormsApplication));
        //    };
        //    FormsApplication.Resume += (s, e) =>
        //    {
        //        Mvx.Resolve<IMvxMessenger>().Publish(new AppResumeMessage(FormsApplication));
        //    };
        //}
    }
}