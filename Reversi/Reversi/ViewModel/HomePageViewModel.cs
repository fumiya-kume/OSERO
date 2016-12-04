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
        public ReactiveProperty<string> AppTitle { get; set; }

        public ReactiveCommand NavigateBattleLogPage { get; set; }
        public HomePageViewModel(Frame page)
        {
            _page = page;
            AppTitle = new ReactiveProperty<string>(Windows.ApplicationModel.Package.Current.DisplayName);

            NavigateBattleLogPage = new ReactiveCommand();
            NavigateBattleLogPage.Subscribe(o =>
            {
                _page.Navigate(typeof(ScoreBoard),null);
            });
        }
    }
}
