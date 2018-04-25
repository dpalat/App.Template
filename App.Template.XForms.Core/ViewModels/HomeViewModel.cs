using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace App.Template.XForms.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public async void ScanBarcode()
        {
            await Mvx.Resolve<IMvxNavigationService>().Navigate<ScanBarcodeViewModel>();
        }
    }
}