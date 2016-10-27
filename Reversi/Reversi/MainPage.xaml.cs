using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Reversi.classes;
using Reversi.Control;
using Reversi.Model;
using static Reversi.classes.Player;
using Player = Reversi.Model.Player;
using Windows.UI.Popups;
using Reversi.Dialog;


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

            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                BlackCount.FontSize = 15;
                WhiteCount.FontSize = 15;
                CpuLabel.Width = 100;
                HumanLabel.Width = 150;
            }

            CountDownTimer.Start();
            BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
            BoardUI.BoardPlayers = reversi.Board.Board;
            BoardUI.ReRendering();

            HumanLabel.Background = new SolidColorBrush(Colors.LightGreen);

            IntelliService = new IntelliGenceService(reversi.Board);
        }

        public CountDownTimer CountDownTimer { get; set; } = new CountDownTimer(180);
        public Player Player { get; set; } = new Player();
        public ReversiLib reversi { get; set; } = new ReversiLib();
        public IntelliGenceService IntelliService { get; set; }
        public SkipCounter WhiteCounter { get; set; } = new SkipCounter();
        public SkipCounter BlackCounter { get; set; } = new SkipCounter();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshInfomatinText();
        }

        private ColorPoint InputCPU()
            => IntelliService.GetShouldSetPoint(Player.NowPlayer);

        private static async Task ShowDialog(string message)
            => await new ContentDialog { Title = message, PrimaryButtonText = "OK" }.ShowAsync();

        private void RefreshInfomatinText()
        {
            ErrorMessage.Glyph = "";
            RefreshWhiteText();
            RefreshBlackText();
        }

        private void RefreshBlackText()
        {
            BlackCount.Glyph = " プレイヤー ●：" + reversi.Board.CountBlackColor() + "個 ";
        }

        private void RefreshWhiteText()
        {
            WhiteCount.Glyph = " CPU ◌：" + reversi.Board.CountWhiteColor() + "個 ";
        }

        private async void BoardUI_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var x = -1;
            var y = -1;
            for (var i = 0; i < 8; i++)
            {
                var X = e.GetPosition((ReversiBoardUI)sender).X;
                var Y = e.GetPosition((ReversiBoardUI)sender).Y;
                if (BoardUI.GetFramePosition(1 + i) < X && X < BoardUI.GetFramePosition(2 + i))
                {
                    x = i;
                }
                if (BoardUI.GetFramePosition(1 + i) < Y && Y < BoardUI.GetFramePosition(2 + i))
                {
                    y = i;
                }
            }
            if (x == -1 || y == -1) return;
            try
            {
                if (reversi.Board.GetEnableColorPointList(Black).Count == 0 && reversi.Board.CountBlackColor() != 0)
                {
                    Player.Skip();
                    await ShowDialog("プレイヤー:スキップします。");
                    BlackCounter.Skip();
                }
                else
                {
                    var point = new ColorPoint(x, y);
                    Debug.Write($"プレイヤー X:{x} Y: {y})\n ");
                    SetColor(point);


                    HumanLabel.Background = null;
                    CpuLabel.Background = new SolidColorBrush(Colors.LightGreen);

                    BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
                    BoardUI.BeforeInputColor = new ColorData(new ColorPoint(x, y), 0);
                }
                await GameEndProcess();
                if (reversi.Board.CountBlackColor() == 2 && reversi.Board.CountWhiteColor() == 2) return;
                if (reversi.Board.GetEnableColorPointList(White).Count == 0 && reversi.Board.CountWhiteColor() != 0)
                {
                    Player.Skip();
                    WhiteCounter.Skip();
                    RefreshInfomatinText();
                    await ShowDialog("CPU:スキップします");
                }
                else
                {
                    var Cpupoint = InputCPU();
                    Debug.Write($"CPU X:{x} Y:{y}\n");
                    SetColor(Cpupoint);

                    HumanLabel.Background = new SolidColorBrush(Colors.LightGreen);
                    CpuLabel.Background = null;

                }
            }
            catch (Exception errorException)
            {
                ErrorMessage.Glyph = errorException.Message;
                Debug.Write(e.ToString());
            }
            await GameEndProcess();
        }

        private async Task GameEndProcess()
        {
            if (!WhiteCounter.IsContinue() || !BlackCounter.IsContinue() || reversi.Board.CountNoneColor() == 0)
            {
                await ShowDialog($"ゲームが終了しました。\n プレイヤー：{reversi.Board.CountBlackColor()}  CPU：{reversi.Board.CountWhiteColor()}");
                ScoreManager.SaveScore(new ScoreData(reversi.Board.CountBlackColor(), reversi.Board.CountWhiteColor()));
                reversi.Board.Init();
                BlackCounter.InIt();
                WhiteCounter.InIt();
                BoardUI.BoardPlayers = reversi.Board.Board;
                BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
                BoardUI.ReRendering();
                RefreshWhiteText();
                RefreshBlackText();
            }
        }


        private void SetColor(ColorPoint point)
        {
            effect.Play();
            reversi.SetStone(point.x, point.y, Player.NowPlayer);
            Player.ChangePlayer();
            BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
            BoardUI.ReRendering();
            RefreshInfomatinText();
            BoardUI.BeforeInputColor = new ColorData(new ColorPoint(point.x, point.y), 0);
        }

        private async void PauseButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await PauseDialog.ShowAsync();
        }

        private void ShowScorePage(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ScoreBoard), e.ToString());
        }

        private async void NewGameStart(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var Dialog = new MessageDialog("新規対局を開始しますか？");
            Dialog.Commands.Add(new UICommand("はい", null, true));
            Dialog.Commands.Add(new UICommand("いいえ", null, false));
            var dialogResult = await Dialog.ShowAsync();
            if (!(bool)dialogResult.Id) return;
            PauseDialog.Hide();
            reversi.Board.Init();
            BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
            RefreshInfomatinText();
            BoardUI.ReRendering();
        }
    }
}