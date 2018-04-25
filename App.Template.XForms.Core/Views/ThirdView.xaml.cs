using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;

namespace App.Template.XForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class ThirdView
    {
        public ThirdView()
        {
            InitializeComponent();
        }
    }
}