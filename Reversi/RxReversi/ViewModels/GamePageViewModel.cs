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
using RxReversi.Services;

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

        public ReactiveCommand<Point> BoardTappedCommand { get; set; }

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

            BoardTappedCommand = new ReactiveCommand<Point>();
            BoardTappedCommand.Subscribe(o =>
            {
                Debug.Write($"X:{o.X} Y:{o.Y}");

                var colorpoint = Position2PointService.Translate(
                    new Point { X = o.X, Y = o.Y },
                    BoardWidth.Value,BoardHeight.Value);
                Debug.Write($"X:{colorpoint.x} Y:{colorpoint.y}");
                Board.SetColor(colorpoint.x, colorpoint.y, Player.NowColor);

                Player.ChangePlayer();

                var AIcolorpoint = new IntelliGenceService(Board).GetShouldSetPoint(Color.White);
                Board.SetColor(AIcolorpoint.x, AIcolorpoint.y, Color.White);
            });

        }
    }
}
