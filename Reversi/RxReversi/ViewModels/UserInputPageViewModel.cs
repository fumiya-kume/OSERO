using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Reactive.Bindings;
using Reactive.Bindings.Interactivity;

namespace RxReversi.ViewModels
{
    public class UserInputPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public DelegateCommand NavigateCommand { get; set; } 

        public UserInputPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            NavigateCommand = new DelegateCommand(() => navigationService.GoBack());
        }

        public ReactiveProperty<string> Text { get; set; }
        
        [RestorableState]
        public ReactiveProperty<int> Age { get; set; }  = new ReactiveProperty<int>(0);

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            ApplicationData.Current.LocalSettings.Values["Age"] = this.Age.Value;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            Text = new ReactiveProperty<string>(e.Parameter as string);
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Age"))
            {
                Age = (ReactiveProperty<int>) ApplicationData.Current.LocalSettings.Values["Age"];
                ApplicationData.Current.LocalSettings.Values.Remove("Age");
            }
        }
    }
}
