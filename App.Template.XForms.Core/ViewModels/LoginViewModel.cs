using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace App.Template.XForms.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        public async void Login()
        {
            await Mvx.Resolve<IMvxNavigationService>().Navigate<MasterDetailViewModel>();
        }
    }
}