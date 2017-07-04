using App.Template.XForms.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace App.Template.XForms.Core.ViewModels
{
    public class MenuViewModel : MvxMasterDetailViewModel<HomeViewModel>
    {
        #region Fields

        private readonly IMvxNavigationService _navigationService;
        private IEnumerable<MenuItem> _menu;
        private MenuItem _selectedMenuItem;
        private MvxCommand<MenuItem> _onSelectedMenuItemChangedCommand;
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

        private ICommand OnSelectedMenuItemChangedCommand
        {
            get
            {
                return _onSelectedMenuItemChangedCommand ?? (_onSelectedMenuItemChangedCommand =
                           new MvxCommand<MenuItem>((item) =>
                           {
                               if (item == null)
                                   return;
                               item.Command.Execute();
                           }));
            }
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
                    Command = new MvxCommand(ClearStackAndShowViewModel<FirstViewModel>)
                },

                new MenuItem()
                {
                    Text = "Second view",
                    Image = "ic_drawer_about.png",
                    Command = new MvxCommand(ClearStackAndShowViewModel<SecondViewModel>)
                },

                new MenuItem()
                {
                    Text = "Third view",
                    Image = "ic_power_settings.png",
                    Command = new MvxCommand(ClearStackAndShowViewModel<ThirdViewModel>)
                }
            };
        }

        public override void RootContentPageActivated()
        {
            SelectedMenuItem = null;
        }

        private void ClearStackAndShowViewModel<TViewModel>() where TViewModel : IMvxViewModel
        {
            var presentationBundle =
                new MvxBundle(new Dictionary<string, string> {{"NavigationMode", "ClearStack"}});
            _navigationService.Navigate<TViewModel>(presentationBundle);
            //ShowViewModel<TViewModel>(presentationBundle:presentationBundle);
        }
    }
}