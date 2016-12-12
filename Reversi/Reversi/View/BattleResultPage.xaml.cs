using Reactive.Bindings;
using Reversi.Model.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace Reversi.View
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class BattleResultPage : Page
    {
        public BattleResultPage()
        {
            this.InitializeComponent();

            NavigateBattlePage.Subscribe(_ => this.Frame.Navigate(typeof(MainPage)));
            NavigateHomePage.Subscribe(_ => this.Frame.Navigate(typeof(HomePage)));
        }

        public ReactiveProperty<string> BattleResultText { get; set; }

        public ReactiveCommand BattleResultShare{ get; set; } = new ReactiveCommand();
        public ReactiveCommand NavigateBattlePage { get; set; } = new ReactiveCommand();
        public ReactiveCommand NavigateHomePage { get; set; } = new ReactiveCommand();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var scoredata = e.Content as ScoreData;
            BattleResultText.Value = $"You: {scoredata.BlackScore} CPU:{scoredata.WhiteScore}";
        }
    }
}
