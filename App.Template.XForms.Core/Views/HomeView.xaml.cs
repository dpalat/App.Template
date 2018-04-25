using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;

namespace App.Template.XForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, WrapInNavigationPage = true, NoHistory = true)]
    public partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}