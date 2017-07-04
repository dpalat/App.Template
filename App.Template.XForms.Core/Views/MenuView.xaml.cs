using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Template.XForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
    }
}
