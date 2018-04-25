using System;
using System.Collections.Generic;
using MvvmCross.Base;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace App.Template.Tests.Base
{
    public class DispatcherMock : MvxMainThreadDispatcher, IMvxViewDispatcher
    {
        public List<MvxViewModelRequest> Requests { get; } = new List<MvxViewModelRequest>();
        public List<MvxPresentationHint> Hints { get; } = new List<MvxPresentationHint>();

        public bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            action();
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            Requests.Add(request);
            return true;
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            Hints.Add(hint);
            return true;
        }
    }
}