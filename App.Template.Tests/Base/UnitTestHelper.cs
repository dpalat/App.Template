using MvvmCross.Base;
using MvvmCross.Core;
using MvvmCross.IoC;
using MvvmCross.Logging;

namespace App.Template.Tests.Base
{
    public static class UnitTestHelper
    {
        public static void ResetContext()
        {
            MvxSingleton.ClearAllSingletons();

            var ioc = MvxIoCProvider.Initialize();
            ioc.RegisterSingleton(ioc);
            ioc.RegisterSingleton<IMvxLog>(new UnitTestTrace());

            MvxSingletonCache.Initialize();
            ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());
        }
    }
}