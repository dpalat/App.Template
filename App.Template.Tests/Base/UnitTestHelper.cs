using MvvmCross.Core;
using MvvmCross.Core.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;

namespace App.Template.Tests.Base
{
    public static class UnitTestHelper
    {
        public static void ResetContext()
        {
            MvxSingleton.ClearAllSingletons();
            var ioc = MvxSimpleIoCContainer.Initialize(null);
            ioc.RegisterSingleton(ioc);
            ioc.RegisterSingleton<IMvxTrace>(new UnitTestTrace());
            MvxSingletonCache.Initialize();
            ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());
            MvxTrace.Initialize();
        }
    }
}