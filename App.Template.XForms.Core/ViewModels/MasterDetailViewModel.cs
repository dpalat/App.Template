using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace App.Template.XForms.Core.ViewModels
{
    public class MasterDetailViewModel : MvxViewModel
    {
        #region Constructors

        public MasterDetailViewModel()
        {
            ShowInitialMenuCommand = new MvxAsyncCommand(ShowInitialViewModel);
            ShowDetailCommand = new MvxAsyncCommand(ShowDetailViewModel);
        }

        #endregion

        #region Properties, Indexers

        public IMvxAsyncCommand ShowDetailCommand { get; }

        public IMvxAsyncCommand ShowInitialMenuCommand { get; }

        #endregion

        #region Methods

        public override void ViewAppeared()
        {
            base.ViewAppeared();
                MvxNotifyTask.Create(async () =>
                {
                    await ShowInitialViewModel();
                    await ShowDetailViewModel();
                });
        }

        private async Task ShowDetailViewModel()
        {
            await Mvx.Resolve<IMvxNavigationService>().Navigate<HomeViewModel>();
        }

        private async Task ShowInitialViewModel()
        {
            await Mvx.Resolve<IMvxNavigationService>().Navigate<MenuViewModel>();
        }

        #endregion
    }
}