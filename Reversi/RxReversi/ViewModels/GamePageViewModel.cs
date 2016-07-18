using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using RxReversi.classes;
using RxReversi.Model;
using static RxReversi.Services.ColorPoint2PointService;

namespace RxReversi.ViewModels
{
    public class GamePageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public Player Player { get; set; } = new Player();
        public ReversiBoard Board { get; set; } = new ReversiBoard();

        public ReactiveProperty<string> NowColor { get; set; }
        public ReactiveProperty<string> BlackStone { get; set; }
        public ReactiveProperty<string> WhiteStone { get; set; }
        public ReactiveProperty<double> BoardWidth { get; set; } = new ReactiveProperty<double>(300);
        public ReactiveProperty<double> BoardHeight { get; set; } = new ReactiveProperty<double>(300);
        public ReactiveProperty<Color[][]> Colors { get; set; }

        public ReactiveCommand<ColorPoint> BoardTappedCommand { get; set; }

        public GamePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            Board.Init();

            Colors = Board
                .ObserveProperty(c => c.Board)
                .ToReactiveProperty();

            NowColor = Player
                .ObserveProperty(c => c.NowColor)
                .Select(c => c.ToString())
                .ToReactiveProperty();

            BlackStone = Board
                .ObserveProperty(c => c.CountBlackColor)
                .Select(c => $"黒：{c}")
                .ToReactiveProperty();

            WhiteStone = Board
                .ObserveProperty(c => c.CountWhiteColor)
                .Select(c => $"白：{c}")
                .ToReactiveProperty();

            BoardTappedCommand = new ReactiveCommand<ColorPoint>();
            BoardTappedCommand
                .Where(point => Util.IsRange((int)point.x, (int)point.y))
                .Where(point => Board.IsNone((int)point.x, (int)point.y))
                .Where(point => Board.IsReversiAllDirectionWithColor((int)point.x, (int)point.y, Player.NowColor))
                .Subscribe(o =>
            {
                //var colorpoint = ReConvert(new Point(o.X, o.Y), (int) BoardWidth.Value, (int) BoardHeight.Value);

                //Board.SetColor(new ColorPoint(o.x,o.y), Player.NowColor);
                Board.SetColor(new ColorPoint(0,0),Color.White );
                Player.ChangePlayer();

                var AIcolorpoint = new IntelliGenceService(Board).GetShouldSetPoint(Color.White);
                Board.SetColor(new ColorPoint(AIcolorpoint.x, AIcolorpoint.y), Color.White);
            });

        }
    }
}
