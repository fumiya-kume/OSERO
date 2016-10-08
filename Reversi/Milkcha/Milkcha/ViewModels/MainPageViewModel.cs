using System.Collections.Generic;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Reactive.Bindings;
using Reactive;

namespace MilkCha.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public ReactiveProperty<string> Greeting { get; set; } = new ReactiveProperty<string>("Hello World");

        public MainPageViewModel(INavigationService navigationService)
        {
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
        }
    }
}
