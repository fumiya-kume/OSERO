using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Reversi.classes;
using Reversi.Model;
// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace Reversi
{
    /// <summary>
    ///     それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            BoardUI.BoardColors = reversi.Board.Board;
            IntelliService = new IntelliGenceService(reversi.Board);
        }

        public ReversiLib reversi { get; set; } = new ReversiLib();
        public IntelliGenceService IntelliService { get; set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ShowDIalog($"現在の色は、{reversi.Player.NowColor}です。");
        }

        private async void enterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await HumanCommand();


                await ShowDIalog($"現在のターンは{reversi.Player.NowColor}です。");
                await ShowDIalog($"現在の白の石の数は、{reversi.Board.CountWhiteColor()}個、黒{reversi.Board.CountBlackColor()}個です。");

                if (!reversi.IsContinue())
                {
                    await ShowDIalog("スキップします");
                    reversi.Player.Skip();
                    if (reversi.Player.SkipCounter >= 2)
                    {
                        await ShowDIalog("ゲームが終了しました。");
                        reversi.Board.Init();
                        reversi.Player.SkipCounter = 0;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                await ShowDIalog("値がおかしいです");
            }
            catch (ReversiLib.OverrideStoneException)
            {
                await ShowDIalog("すでに石が置かれています");
            }
            catch (Exception)
            {
                await ShowDIalog("エラーが起きているようです");
            }
            BoardUI.ReRendering();
        }

        private ColorData AICommand()
            => IntelliService.GetShouldSetPoint(reversi.Player.NowColor);

        private async Task HumanCommand()
        {
            var x = Util.Alphabet2Int(XText.Text);
            var y = int.Parse(YText.Text);
            //配列は、0からスタートしてるからその調整
            y = y - 1;

            reversi.SetStone(x, y);
            reversi.Player.ChangePlayer();

            await ShowDIalog("石を置くことに成功しました");
            XText.Text = "";
            YText.Text = "";
        }

        private static async Task ShowDIalog(string message)
            => await new ContentDialog {Title = message, PrimaryButtonText = "OK"}.ShowAsync();
    }
}