using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using static ReversiUWP.Model.ReversiLib;
using  static ReversiUWP.Model.Util;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace ReversiUWP
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ReversiUWP.Model.ReversiLib reversi { get; set; } = new ReversiUWP.Model.ReversiLib();
        public MainPage()
        {
            this.InitializeComponent();
            this.BoardUI.BoardColors = reversi.Board.Board;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await new ContentDialog() { Title = $"現在の色は、{reversi.Player.NowColor}です。", PrimaryButtonText = "OK" }.ShowAsync();
        }

        private async void enterButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                var x = Alphabet2int(XText.Text);
                var y = int.Parse(YText.Text);
                //配列は、0からスタートしてるからその調整
                y = y - 1;
            
                reversi.SetStone(x, y);
                reversi.Player.Change();

                await new ContentDialog() {Title = $"石を置くことに成功しました",PrimaryButtonText = "OK"}.ShowAsync();

                await new ContentDialog() { Title = $"現在のターンは{reversi.Player.NowColor.ToString()}です。",PrimaryButtonText="OK" }.ShowAsync();

                await
                    new ContentDialog()
                    {
                        Title = $"現在の白の石の数は、{reversi.Board.CountWhiteColor()}個、黒{reversi.Board.CountBlackColor()}個です。",
                        PrimaryButtonText = "OK"
                    }
                        .ShowAsync();

                if (!reversi.IsContinue())
                {
                    await new ContentDialog() {Title = "スキップします", PrimaryButtonText = "OK"}.ShowAsync();
                    reversi.Player.Skip();
                }
            }
            catch (IndexOutOfRangeException)
            {
                await new ContentDialog() { Title = "あたいがおかしいです", PrimaryButtonText = "ok" }.ShowAsync();
            }
            catch (OverrideStoneException)
            {
                await new ContentDialog() { Title = "値がおかしいです", PrimaryButtonText = "OK" }.ShowAsync();
            }
            catch (Exception)
            {
                await new ContentDialog() { Title = "値がおかしいです", PrimaryButtonText = "OK" }.ShowAsync();
            }
            BoardUI.ReRendering();            
        }
    }
}
