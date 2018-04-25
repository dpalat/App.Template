using MvvmCross.Forms.Presenters.Attributes;

namespace App.Template.XForms.Core.Views
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false)]
    public partial class MasterDetailView
    {
        #region Constructors

        public MasterDetailView()
        {
            InitializeComponent();
        }

        #endregion
    }
}