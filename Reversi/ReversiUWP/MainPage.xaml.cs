using Windows.UI.Xaml.Controls;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace ReversiUWP
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public string[][] board { get; set; } =
        {
            new []{"StoneA1","StoneB1","StoneC1","StoneD1","StoneE1","StoneF1","StoneG1","StoneH1"},
            new []{"StoneA2","StoneB2","StoneC2","StoneD2","StoneE2","StoneF2","StoneG2","StoneH2"},
            new []{ "StoneA3","StoneB3","StoneC3","StoneD3","StoneE3","StoneF3","StoneG3","StoneH3"},
            new []{"StoneA4","StoneB4","StoneC4","StoneD4","StoneE4","StoneF4","StoneG4","StoneH4"},
            new []{"StoneA5","StoneB5","StoneC5","StoneD5","StoneE5","StoneF5","StoneG5","StoneH5"},
            new []{ "StoneA6","StoneB6","StoneC6","StoneD6","StoneE6","StoneF6","StoneG6","StoneH6"},
            new []{ "StoneA7","StoneB7","StoneC7","StoneD7","StoneE7","StoneF7","StoneG7","StoneH7"},
            new []{ "StoneA8","StoneB8","StoneC8","StoneD8","StoneE8","StoneF8","StoneG8","StoneH8"}
        };
    }
}
