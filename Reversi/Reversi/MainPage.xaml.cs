using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Reversi.classes;
using static Reversi.classes.Color;
using Reversi.Model;
using System.Diagnostics.Contracts;
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

        public Player Player { get; set; } = new Player();
        public ReversiLib reversi { get; set; } = new ReversiLib();
        public IntelliGenceService IntelliService { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshInfomatinText();
        }

        private async void enterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ColorPoint point;

                point = InputHuman();
                await SetClor(point);

                point = InputAI();
                await SetClor(point);

                await PlayerCheck();
            }
            catch (Exception errorException)
            {
                await ShowDIalog(errorException.Message);
            }
        }

        private async Task PlayerCheck()
        {
            if (!reversi.IsContinue())
            {
                await ShowDIalog("スキップします");
                Player.Skip();
                if (Player.IsEndGame())
                {
                    await ShowDIalog("ゲームが終了しました。");
                    reversi.Board.Init();
                    Player.SkipCounter = 0;
                }
            }
        }

        private ColorPoint InputAI()
            => IntelliService.GetShouldSetPoint(Player.NowColor);

        private ColorPoint InputHuman()
        {
            var x = Util.Alphabet2Int(XText.Text);
            var y = int.Parse(YText.Text);
            //配列は、0からスタートしてるからその調整
            y = y - 1;
            XText.Text = "";
            YText.Text = "";
            return new ColorPoint { x = x, y = y };
        }

        private async Task SetClor(ColorPoint point)
        {
            reversi.SetStone(point.x, point.y, Player.NowColor);
            Player.ChangePlayer();
            BoardUI.ReRendering();
            await ShowDIalog("石を置くことができました");
            RefreshInfomatinText();
        }
        private static async Task ShowDIalog(string message)
            => await new ContentDialog { Title = message, PrimaryButtonText = "OK" }.ShowAsync();

        private void RefreshInfomatinText()
        {
            var PlayerText = "";
            switch (Player.NowColor)
            {
                case Black:
                    PlayerText = "あなた";
                    break;
                case White:
                    PlayerText = "AI";
                    break;
                case None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            InfomationText.Text =
                $"現在のプレイヤーは{PlayerText}です\r" +
                $"白色の駒の数は:{reversi.Board.CountWhiteColor()}個です\r" +
                $"黒色の駒の数は:{reversi.Board.CountBlackColor()}個です\r";
        }
    }
}