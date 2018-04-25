using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Template.XForms.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace App.Template.XForms.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        #region Fields

        private readonly IMvxNavigationService _navigationService;
        private IEnumerable<MenuItem> _menu;
        private MenuItem _selectedMenuItem;
        private MvxAsyncCommand<MenuItem> _onSelectedMenuItemChangedCommand;
        private string _userFullName;
        private string _userEmail;

        #endregion Fields

        #region Properties

        public IEnumerable<MenuItem> Menu
        {
            get => _menu;
            set => SetProperty(ref _menu, value);
        }

        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                SetProperty(ref _selectedMenuItem, value);
                if (value != null)
                {
                    OnSelectedMenuItemChangedCommand.Execute(value);
                }
            }
        }

        public string UserFullName
        {
            get => _userFullName;
            set => SetProperty(ref _userFullName, value);
        }

        public string UserEmail
        {
            get => _userEmail;
            set => SetProperty(ref _userEmail, value);
        }

        private ICommand OnSelectedMenuItemChangedCommand => _onSelectedMenuItemChangedCommand ?? (_onSelectedMenuItemChangedCommand =
                                                                 new MvxAsyncCommand<MenuItem>(Execute));

        private static async Task Execute(MenuItem menuItem)
        {
            if (menuItem == null) return;
            await menuItem.Command.ExecuteAsync();
        }

        #endregion Properties

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            UserFullName = "Bruce Wayne";
            UserEmail = "batman@gothamcity.com";
            Menu = new[]
            {
                new MenuItem()
                {
                    Text = "First view",
                    Image = "ic_drawer_settings.png",
                    Command = new MvxAsyncCommand(async () => await ClearStackAndShowViewModel<FirstViewModel>())
                },

                new MenuItem()
                {
                    Text = "Second view",
                    Image = "ic_drawer_about.png",
                    Command = new MvxAsyncCommand(async () => await ClearStackAndShowViewModel<SecondViewModel>())
                },

                new MenuItem()
                {
                    Text = "Third view",
                    Image = "ic_power_settings.png",
                    Command = new MvxAsyncCommand(async () => await ClearStackAndShowViewModel<ThirdViewModel>())
                }
            };
            _navigationService.Navigate<HomeViewModel>();
        }

        private async Task ClearStackAndShowViewModel<TViewModel>() where TViewModel : IMvxViewModel
        {
            await _navigationService.Navigate<TViewModel>();
        }
    }
}