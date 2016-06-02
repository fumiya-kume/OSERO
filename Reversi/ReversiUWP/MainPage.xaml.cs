using Windows.UI.Xaml.Controls;
using ReversiLib;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace ReversiUWP
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Reversi Reversi { get; set; } = new Reversi();
        public Board board { get; set; } = new Board();

        public MainPage()
        {
            this.InitializeComponent();
            board.Init();
        }
    }
}
