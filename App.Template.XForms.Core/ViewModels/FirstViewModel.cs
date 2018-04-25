using MvvmCross.ViewModels;

namespace App.Template.XForms.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private static int _ctorCount;

        public int CtorCount => _ctorCount;

        public FirstViewModel()
        {
            _ctorCount++;
        }

        public void ResetCounter()
        {
            _ctorCount = 0;
            RaisePropertyChanged(nameof(CtorCount));
        }
    }
}