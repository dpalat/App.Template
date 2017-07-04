using MvvmCross.Core.ViewModels;

namespace App.Template.XForms.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public void ScanBarcode()
        {

            ShowViewModel<ScanBarcodeViewModel>();
        }
    }
}