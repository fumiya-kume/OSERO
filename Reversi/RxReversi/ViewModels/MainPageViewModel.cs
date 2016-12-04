using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using Windows.Storage;

namespace RxReversi.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public DelegateCommand GameStartCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            GameStartCommand = new DelegateCommand(() => navigationService.Navigate("Game", text));
        }

        private string text;
        [RestorableState]
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { SetProperty(ref age, value); }
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
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey("Age"))
                {
                    this.Age = (int)ApplicationData.Current.LocalSettings.Values["Age"];
                    ApplicationData.Current.LocalSettings.Values.Remove("Age");
                }
            }
        }
    }
}
