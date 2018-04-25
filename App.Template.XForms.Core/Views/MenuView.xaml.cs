using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Template.XForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false)]
    public partial class MenuView
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            ViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName != nameof(ViewModel.SelectedMenuItem)) return;
                if (Parent is MasterDetailPage master && master.IsPresented) master.IsPresented = !master.IsPresented;
            };
        }
    }
}
