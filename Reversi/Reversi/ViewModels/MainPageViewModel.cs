using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using Windows.Storage;
using Reactive.Bindings;

namespace Reversi.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public ReactiveProperty<string> Greeting { get; set; } = new ReactiveProperty<string>("Hello World");

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
