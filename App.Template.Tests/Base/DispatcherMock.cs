using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using System;
using System.Collections.Generic;

namespace App.Template.Tests.Base
{
    public class DispatcherMock : MvxMainThreadDispatcher, IMvxViewDispatcher
    {
        public List<MvxViewModelRequest> Requests { get; } = new List<MvxViewModelRequest>();
        public List<MvxPresentationHint> Hints { get; } = new List<MvxPresentationHint>();

        public bool RequestMainThreadAction(Action action)
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