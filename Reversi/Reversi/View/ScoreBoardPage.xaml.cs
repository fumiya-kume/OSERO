using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Reversi.Model;
using Reversi.ViewModel;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace Reversi.View
{

    /// <summary>
    ///     それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class ScoreBoard : Page
    {
        public ScoreBoardPageViewModel ScoreBoardPageViewModel { get; set; } = new ScoreBoardPageViewModel(Window.Current.Content as Frame);

        private readonly ScoreClient _scoreUtil;

        public ScoreBoard()
        {
            _scoreUtil = new ScoreClient();
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += (sender, args) =>
            {
                var rootframe = Window.Current.Content as Frame;
                args.Handled = (rootframe != null) && rootframe.CanGoBack && (args.Handled == false);
                args.Handled = true;
                rootframe?.GoBack();
            };
        }
    }
}