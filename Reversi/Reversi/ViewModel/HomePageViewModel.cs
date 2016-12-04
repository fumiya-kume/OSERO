using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Reactive.Bindings;

namespace Reversi.ViewModel
{
    public class HomePageViewModel
    {
        private readonly Frame _page;
        public ReactiveProperty<string> AppTitle { get; set; } = new ReactiveProperty<string>(Windows.ApplicationModel.Package.Current.DisplayName);

        public ReactiveCommand NavigateBattleLogPage { get; set; } = new ReactiveCommand();
        public ReactiveCommand NavigateBattlePage { get; set; } = new ReactiveCommand();
        public HomePageViewModel(Frame page)
        {
            _page = page;
            
            NavigateBattleLogPage.Subscribe(o =>
            {
                _page.Navigate(typeof(ScoreBoard),null);
            });

            NavigateBattlePage.Subscribe(_ =>
            {
                _page.Navigate(typeof(ScoreBoard), null);
            });
        }
    }
}
