using Android.Content;
using MvvmCross.Binding;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Bindings;
using MvvmCross.Forms.Droid.Presenters;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using System.Collections.Generic;
using System.Reflection;

namespace App.Template.XForms.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
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

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            //var presenter = new MvxFormsDroidPagePresenter();
            var presenter = new MvxFormsDroidMasterDetailPagePresenter();
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

        protected override IMvxAndroidViewsContainer CreateViewsContainer(Context applicationContext)
        {
            var viewsContainer =
                Core.App.LoadViewsContainer((IMvxViewsContainer) base.CreateViewsContainer(applicationContext));
            return (IMvxAndroidViewsContainer) viewsContainer;
        }
    }
}