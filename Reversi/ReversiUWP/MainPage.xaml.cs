using System;
using Windows.UI.Xaml.Controls;
using static ReversiUWP.Model.ReversiLib;

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

        private async void enterButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var x = int.Parse(XText.Text);
            var y = int.Parse(YText.Text);

            try
            {
                reversi.SetStone(x, y);
            }
            catch (IndexOutOfRangeException)
            {
                await new ContentDialog() { Title = "あたいがおかしいです", PrimaryButtonText = "ok" }.ShowAsync();
                throw;
            }
            catch (OverrideStoneException)
            {
                await new ContentDialog() { Title = "値がおかしいです", PrimaryButtonText = "OK" }.ShowAsync();
                throw;
            }
            BoardUI.ReRendering();
        }
    }
}
