using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenters;

namespace App.Template.XForms.Core.MvvmCross
{
    public class MvxFormsViewLoader : MvxFormsPageLoader
    {
        protected override string GetPageName(MvxViewModelRequest request)
        {
            var viewModelName = request.ViewModelType.Name;
            return viewModelName.Replace(MvvmConfig.ViewModelSuffix, MvvmConfig.ViewSuffix);
        }
    }   
}