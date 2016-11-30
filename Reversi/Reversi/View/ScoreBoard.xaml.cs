using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Reversi.Model;
using Reversi.Model.classes;
using static Reversi.Model.SettingHelper;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace Reversi
{
    /// <summary>
    ///     それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class ScoreBoard : Page
    {
        private readonly ScoreClient _scoreUtil;

        public ScoreBoard()
        {
            _scoreUtil = new ScoreClient();
            InitializeComponent();


            SystemNavigationManager.GetForCurrentView().BackRequested += (sender, args) =>
            {
                var rootframe = Window.Current.Content as Frame;
                if ((rootframe != null) && rootframe.CanGoBack && (args.Handled == false))
                {
                    args.Handled = true;
                    rootframe.GoBack();
                }
            };
        }

        /// <summary>
        ///     スコアがない場合にテキストを表示させる
        /// </summary>
        private async void UpdateScoreDataText()
            => NonScoreText.Visibility = (await _scoreUtil.LoadAllScores()).Count == 0 ? Visibility.Visible : Visibility.Collapsed;

        /// <summary>
        ///     リストのデータを端末に保存されているデータを利用して再読み込みする
        /// </summary>
        private async void UpdateListData() => ScoreList.ItemsSource = (await _scoreUtil.LoadAllScores()).ToList();


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var rootframe = Window.Current.Content as Frame;
            if ((rootframe != null) && rootframe.CanGoBack)
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
        }

        private async void DeleteScore(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("保存されているスコアを初期化します。");
            await dialog.ShowAsync();
            _scoreUtil.ClearScore();
            UpdateScoreDataText();
            UpdateListData();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
#if DEBUG
            _scoreUtil.ClearScore();
            
            for (var i = 0; i < 100; i++)
            {
                await _scoreUtil.AddScore(GenerateDummyScoreData());
            }

#endif
            UpdateScoreDataText();
            UpdateListData();
        }

        private static ScoreData GenerateDummyScoreData()
        {
            return new ScoreData(new Random().Next(30), new Random().Next(30));
        }

        //スコアを初期化する
    }
}