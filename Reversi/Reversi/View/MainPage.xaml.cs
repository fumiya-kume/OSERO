using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.System.Profile;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Reversi.Control;
using Reversi.Model;
using Reversi.Model.classes;
using Reversi.ViewModel;
using static Reversi.Model.classes.Player;
using PlayerClient = Reversi.Model.PlayerClient;
using Reactive.Bindings;
using Reversi.View;
using System.Collections.ObjectModel;
using System.Collections.Generic;


// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace Reversi
{
    /// <summary>
    ///     それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel MainPageViewModel { get; set; } = new MainPageViewModel();

        public ReactiveProperty<int> PlayerPieceCount { get; set; } = new ReactiveProperty<int>(0);
        public ReactiveProperty<int> CPUPieceCount { get; set; } = new ReactiveProperty<int>(0);

        public ObservableCollection<BattleLoginTurn> BattleLog { get; set; } = new ObservableCollection<BattleLoginTurn>();

        public ReactiveCommand NavigateNewBattleField { get; set; } = new ReactiveCommand();
        public ReactiveCommand NavigateSetting { get; set; } = new ReactiveCommand();
        public ReactiveCommand NavigateHome { get; set; } = new ReactiveCommand();
        public ReactiveCommand NavigateBattleResult { get; set; } = new ReactiveCommand();
        public MainPage()
        {
            InitializeComponent();

            NavigateNewBattleField.Subscribe(_ =>
            {
                reversi.Board.Init();
                BlackCounter.InIt();
                WhiteCounter.InIt();
                BoardUI.BoardPlayers = reversi.Board.Board;
                BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
                BoardUI.ReRendering();
                CPUPieceCount.Value = reversi.Board.CountWhiteColor();
                PlayerPieceCount.Value = reversi.Board.CountBlackColor();
            });
            NavigateHome.Subscribe(_ => this.Frame.Navigate(typeof(HomePage)));
            NavigateBattleResult.Subscribe(_ => this.Frame.Navigate(typeof(BattleResultPage), new ScoreData(reversi.Board.CountBlackColor(), reversi.Board.CountWhiteColor())));

            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {

            }

            BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
            BoardUI.BoardPlayers = reversi.Board.Board;
            BoardUI.ReRendering();
            CPUPieceCount.Value = reversi.Board.CountWhiteColor();
            PlayerPieceCount.Value = reversi.Board.CountBlackColor();

            IntelliService = new CPU(reversi.Board);
        }

        public PlayerClient Player { get; set; } = new PlayerClient();
        public ReversiLib reversi { get; set; } = new ReversiLib();
        public CPU IntelliService { get; set; }
        public SkipCounter WhiteCounter { get; set; } = new SkipCounter();
        public SkipCounter BlackCounter { get; set; } = new SkipCounter();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshInfomatinText();
        }

        private Tuple<int, int> InputCPU()
            => IntelliService.GetShouldSetPoint(Player.NowPlayer);

        private static async Task ShowDialog(string message)
            => await new ContentDialog { Title = message, PrimaryButtonText = "OK" }.ShowAsync();

        private void RefreshInfomatinText()
        {
        }



        private async void BoardUI_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var x = -1;
            var y = -1;
            for (var i = 0; i < 8; i++)
            {
                var X = e.GetPosition((ReversiBoardUI)sender).X;
                var Y = e.GetPosition((ReversiBoardUI)sender).Y;
                if ((BoardUI.GetFramePosition(i) < X) && (X < BoardUI.GetFramePosition(1 + i)))
                    x = i;
                if ((BoardUI.GetFramePosition(i) < Y) && (Y < BoardUI.GetFramePosition(1 + i)))
                    y = i;
            }
            if ((x == -1) || (y == -1)) return;
            try
            {
                if ((reversi.Board.GetEnableColorPointList(Black).Count == 0) && (reversi.Board.CountBlackColor() != 0))
                {
                    Player.Skip();
                    await ShowDialog("プレイヤー:スキップします。");
                    BlackCounter.Skip();
                }
                else
                {
                    var point = new Tuple<int, int>(x, y);
                    Debug.Write($"プレイヤー X:{x} Y: {y})\n ");
                    SetColor(point);

                    BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
                    BoardUI.BeforeInputColor = new ColorData(new Tuple<int, int>(x, y), 0);
                }
                await GameEndProcess();
                if ((reversi.Board.CountBlackColor() == 2) && (reversi.Board.CountWhiteColor() == 2)) return;
                if ((reversi.Board.GetEnableColorPointList(White).Count == 0) && (reversi.Board.CountWhiteColor() != 0))
                {
                    Player.Skip();
                    WhiteCounter.Skip();
                    RefreshInfomatinText();
                    await ShowDialog("CPU:スキップします");
                }
                else
                {
                    var Cpupoint = InputCPU();
                    SetColor(Cpupoint);

                }
            }
            catch (Exception exception)
            {
                Debug.Write(exception.ToString());
            }
            await GameEndProcess();
        }

        private async Task GameEndProcess()
        {
            if (!WhiteCounter.IsContinue() || !BlackCounter.IsContinue() || (reversi.Board.CountNoneColor() == 0))
            {
                await
                    ShowDialog(
                        $"ゲームが終了しました。\n プレイヤー：{reversi.Board.CountBlackColor()}  CPU：{reversi.Board.CountWhiteColor()}");
                var scoreData = new ScoreData(reversi.Board.CountBlackColor(), reversi.Board.CountWhiteColor());
                await new ScoreClient().AddScore(scoreData);
                reversi.Board.Init();
                BlackCounter.InIt();
                WhiteCounter.InIt();
                BoardUI.BoardPlayers = reversi.Board.Board;
                BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
                BoardUI.ReRendering();
                NavigateBattleResult.Subscribe();
            }
        }


        private void SetColor(Tuple<int, int> point)
        {
            effect.Play();
            reversi.SetStone(point.Item1, point.Item2, Player.NowPlayer);
            Player.ChangePlayer();
            BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
            BoardUI.ReRendering();
            RefreshInfomatinText();
            var latestInput = new ColorData(new Tuple<int, int>(point.Item1, point.Item2), 0);
            BoardUI.BeforeInputColor = latestInput;
            BattleLog.Add(new BattleLoginTurn { player = Player.NowPlayer, PositionList = reversi.Board.GetPieceReversiAllDirection(point.Item1,point.Item2,Player.NowPlayer) });

            CPUPieceCount.Value = reversi.Board.CountWhiteColor();
            PlayerPieceCount.Value = reversi.Board.CountBlackColor();
        }


        private void ShowScorePage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ScoreBoard), e.ToString());
        }

        private async void NewGameStart(object sender, RoutedEventArgs e)
        {
            var Dialog = new MessageDialog("新規ゲームを開始しますか？");
            Dialog.Commands.Add(new UICommand("はい", null, true));
            Dialog.Commands.Add(new UICommand("いいえ", null, false));
            var dialogResult = await Dialog.ShowAsync();
            if (!(bool)dialogResult.Id) return;
            reversi.Board.Init();
            BoardUI.EnableColorPointList = reversi.Board.GetEnableColorPointList(Black);
            RefreshInfomatinText();
            BoardUI.ReRendering();
        }

    }
    public class BattleLoginTurn
    {
        public string ResultText { get { return $"{player.ToString()}に{PositionList.Count} 個プラス"; } }
        public Player player;
        public List<Tuple<int, int>> PositionList;
    }
}