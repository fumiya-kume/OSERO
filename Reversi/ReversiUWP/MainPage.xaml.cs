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
            try
            {
                var x = int.Parse(XText.Text);
                var y = Alphabet2int(YText.Text);
            
                reversi.SetStone(x, y);
                reversi.Player.Change();
                await new ContentDialog() { Title = $"現在のターンは{reversi.Player.NowColor.ToString()}です。",PrimaryButtonText="OK" }.ShowAsync();
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

        private int Alphabet2int(string text)
        {
            switch (text)
            {
                case  "A":
                    return 0;
                case "B":
                    return 1;
                case "C":
                    return 2;
                case "D":
                    return 3;
                case "E":
                    return 4;
                case "F":
                    return 5;
                case "G":
                    return 6;
                case "H":
                    return 7;
                default:
                    return -1;
            }
        }
    }
}
