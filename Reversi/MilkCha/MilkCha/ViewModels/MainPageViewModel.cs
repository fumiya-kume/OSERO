using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using MilkCha.Views;
using Prism.Unity.Navigation;
using Reactive.Bindings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MilkCha.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public ReactiveProperty<string> Title { get; set; } = new ReactiveProperty<string>();
        public MainPageViewModel(INavigationService navigationService)
        {
            
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title.Value = (string)parameters["title"] + " and Prism";
        }
    }
}
