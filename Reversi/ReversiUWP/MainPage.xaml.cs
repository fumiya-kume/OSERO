using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ReversiUWP.Model;
using static ReversiUWP.Model.ReversiLib;
using static ReversiUWP.Model.Util;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace ReversiUWP
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
        }

        public ReversiLib reversi { get; set; } = new ReversiLib();

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await
                new ContentDialog {Title = $"現在の色は、{reversi.Player.NowColor}です。", PrimaryButtonText = "OK"}.ShowAsync();
        }

        private async void enterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = Alphabet2int(XText.Text);
                var y = int.Parse(YText.Text);
                //配列は、0からスタートしてるからその調整
                y = y - 1;

                reversi.SetStone(x, y);
                reversi.Player.Change();

                await new ContentDialog {Title = "石を置くことに成功しました", PrimaryButtonText = "OK"}.ShowAsync();
                XText.Text = "";
                YText.Text = "";

                await
                    new ContentDialog {Title = $"現在のターンは{reversi.Player.NowColor}です。", PrimaryButtonText = "OK"}
                        .ShowAsync();

                await
                    new ContentDialog
                    {
                        Title = $"現在の白の石の数は、{reversi.Board.CountWhiteColor()}個、黒{reversi.Board.CountBlackColor()}個です。",
                        PrimaryButtonText = "OK"
                    }
                        .ShowAsync();

                if (!reversi.IsContinue())
                {
                    await new ContentDialog {Title = "スキップします", PrimaryButtonText = "OK"}.ShowAsync();
                    reversi.Player.Skip();
                    if (reversi.Player.SkipCounter >= 2)
                    {
                        await new ContentDialog {Title = "ゲームが終了しました。", PrimaryButtonText = "OK"}.ShowAsync();
                        reversi.Board.Init();
                        reversi.Player.SkipCounter = 0;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                await new ContentDialog {Title = "値がおかしいです", PrimaryButtonText = "ok"}.ShowAsync();
            }
            catch (OverrideStoneException)
            {
                await new ContentDialog {Title = "すでに石が置かれています", PrimaryButtonText = "OK"}.ShowAsync();
            }
            catch (Exception)
            {
                await new ContentDialog {Title = "エラーが起きているようです。", PrimaryButtonText = "OK"}.ShowAsync();
            }
            BoardUI.ReRendering();
        }
    }
}