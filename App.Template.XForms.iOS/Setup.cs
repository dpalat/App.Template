using ImageCircle.Forms.Plugin.iOS;
using MvvmCross.Binding;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Bindings;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.iOS.Presenters;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using System.Collections.Generic;
using System.Reflection;
using UIKit;

namespace App.Template.XForms.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();


            var xamarinFormsApp = new MvxFormsApplication();
            //var presenter = new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
            var presenter = new MvxFormsIosMasterDetailPagePresenter(Window, xamarinFormsApp);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);
            return presenter;
        }


        protected override IEnumerable<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn =
                    new List<Assembly>(base.ValueConverterAssemblies) {typeof(MvxLanguageConverter).Assembly};
                return toReturn;
            }
        }

        protected override void InitializeBindingBuilder()
        {
            var bindingBuilder = CreateBindingBuilder();

            RegisterBindingBuilderCallbacks();
            bindingBuilder.DoRegistration();
        }

        protected new MvxBindingBuilder CreateBindingBuilder()
        {
            return new MvxFormsBindingBuilder();
        }

        protected sealed override IMvxIosViewsContainer CreateIosViewsContainer()
        {
            var viewsContainer = Core.App.LoadViewsContainer(base.CreateIosViewsContainer());
            return (IMvxIosViewsContainer) viewsContainer;
        }
    }
}