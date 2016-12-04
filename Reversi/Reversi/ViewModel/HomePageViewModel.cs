using System;
using Windows.UI.Xaml.Controls;
using Reactive.Bindings;
using static Windows.ApplicationModel.Package;

namespace Reversi.ViewModel
{
    public class HomePageViewModel
    {
        private readonly Frame _page;
        public ReactiveProperty<string> AppTitle { get; set; } = new ReactiveProperty<string>(Current.DisplayName);

        public ReactiveCommand NavigateBattleLogPage { get; set; } = new ReactiveCommand();
        public ReactiveCommand NavigateBattlePage { get; set; } = new ReactiveCommand();
        public HomePageViewModel(Frame page)
        {
            _page = page;

            NavigateBattleLogPage.Subscribe(_ => _page.Navigate(typeof(View.ScoreBoard), null));
            NavigateBattlePage.Subscribe(_ => _page.Navigate(typeof(View.ScoreBoard), null));
        }
    }
}
