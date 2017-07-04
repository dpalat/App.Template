using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Platform;
using System.Collections.Generic;

namespace App.Template.Tests.Base
{
    [TestClass]
    public abstract class BaseTest
    {
        private List<string> _traceLog = new List<string>();

        protected DispatcherMock ViewDispatcherMock { get; private set; }

        protected List<string> TraceLog
        {
            get
            {
                Mvx.TryResolve(out IMvxTrace trace);
                _traceLog = ((UnitTestTrace)trace)?.TraceLog;
                return _traceLog;
            }
        }

        [TestInitialize]
        public virtual void Setup()
        {
            UnitTestHelper.ResetContext();
        }

        [TestCleanup]
        public virtual void TearDown()
        {
            UnitTestHelper.ResetContext();
        }

        public virtual void InitializeViewDispatcher()
        {
            ViewDispatcherMock = new DispatcherMock();
            Mvx.RegisterSingleton<IMvxViewDispatcher>(ViewDispatcherMock);
            Mvx.RegisterSingleton<IMvxMainThreadDispatcher>(ViewDispatcherMock);
        }
    }
}