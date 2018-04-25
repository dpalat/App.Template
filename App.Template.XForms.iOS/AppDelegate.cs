using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using App.Template.XForms.Core;
using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace App.Template.XForms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, FormsApp>
    {
        #region Public Enums

        public enum Signal
        {
            Sigbus = 10,
            Sigsegv = 11
        }

        #endregion

        #region Methods

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            EnableCrashReporting();
            var result = base.FinishedLaunching(app, options);
            new MvvmCross.Plugin.MethodBinding.Plugin().Load();
            return result;
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        private static void CurrentDomainOnUnhandledException(object sender,
            UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
        }

        private static void EnableCrashReporting()
        {
            var sigbus = Marshal.AllocHGlobal(512);
            var sigsegv = Marshal.AllocHGlobal(512);

            // Store Mono SIGSEGV and SIGBUS handlers
            sigaction(Signal.Sigbus, IntPtr.Zero, sigbus);
            sigaction(Signal.Sigsegv, IntPtr.Zero, sigsegv);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            //Crashlytics.Instance.Initialize();

            // Restore Mono SIGSEGV and SIGBUS handlers
            sigaction(Signal.Sigbus, sigbus, IntPtr.Zero);
            sigaction(Signal.Sigsegv, sigsegv, IntPtr.Zero);

            Marshal.FreeHGlobal(sigbus);
            Marshal.FreeHGlobal(sigsegv);
        }

        [DllImport("libc")]
        private static extern int sigaction(Signal sig, IntPtr act, IntPtr oact);

        private static void TaskSchedulerOnUnobservedTaskException(object sender,
            UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            unobservedTaskExceptionEventArgs.SetObserved();
        }

        #endregion
    }
}