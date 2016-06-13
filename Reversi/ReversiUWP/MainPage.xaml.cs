using Windows.UI.Xaml.Controls;

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
    }
}
