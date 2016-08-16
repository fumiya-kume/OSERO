using System;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using System.Reactive.Linq;
using Windows.Storage;
using Reactive.Bindings;

namespace Reversi.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public INavigationService navigationService;
        
        public void GameShow() => navigationService.Navigate("Game", null);
        public void SettingShow() => navigationService.Navigate("Setting", null);
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            if (e.NavigationMode == Windows.UI.Xaml.Navigation.NavigationMode.Back)
            {

            }
        }
    }
}
