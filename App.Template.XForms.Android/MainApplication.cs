using System;
using Android.App;
using Android.OS;
using Android.Runtime;

namespace App.Template.XForms.Android
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        #region Constructors

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
            : base(handle, transer)
        {
        }

        #endregion

        #region Interface Implementations

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
        }

        public void OnActivityStopped(Activity activity)
        {
        }

        #endregion

        #region Methods

        public override void OnCreate()
        {
            base.OnCreate();
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            //TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        private static void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            e.Handled = true;
            var ex = e.Exception;
        }

        #endregion

        //private static void TaskSchedulerOnUnobservedTaskException(object sender,
        //    UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        //{
        //}

        //private static void CurrentDomainOnUnhandledException(object sender,
        //    UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        //{
        //}
    }
}