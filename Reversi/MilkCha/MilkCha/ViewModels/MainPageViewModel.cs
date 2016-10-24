using Prism.Mvvm;
using Prism.Navigation;
using MilkCha.Model;
using Reactive.Bindings;

namespace MilkCha.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public Game Game { get; set; }

        public ReactiveProperty<string> Title { get; set; }
        public MainPageViewModel(INavigationService navigationService,Game _game)
        {
            Game = _game;
            
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //if (parameters.ContainsKey("title"))
            //    Title.Value = (string)parameters["title"] + " and Prism";
        }
    }
}
