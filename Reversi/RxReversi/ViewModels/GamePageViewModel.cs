using System;
using System.Reactive.Linq;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using RxReversi.classes;
using RxReversi.Model;

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


        private ReactiveProperty<Color[][]> _colors;
        public ReactiveProperty<Color[][]> Colors { get; set; }

        public ReactiveCommand<ColorPoint> BoardTappedCommand { get; set; }

        public GamePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            
            Colors = Board
                .ObserveProperty(c => c.Board)
                .ToReactiveProperty();

            NowColor = Player
                .ObserveProperty(c => c.NowColor)
                .Select(c => c.ToString())
                .ToReactiveProperty();

            //BlackStone = Board
            //    .ObserveProperty(c => c.Board)
            //    .Select(c => $"黒：{Board.CountBlackColor.ToString()}")
            //    .ToReactiveProperty();

            //WhiteStone = Board
            //    .ObserveProperty(c => c.CountWhiteColor)
            //    .Select(c => $"白：{c}")
            //    .ToReactiveProperty();

            Board.Init();

            BoardTappedCommand = new ReactiveCommand<ColorPoint>();
            BoardTappedCommand
                .Where(point => Util.IsRange(point.x, point.y))
                .Where(point => Board.IsNone(point.x, point.y))
                .Where(point => Board.IsReversiAllDirectionWithColor(point.x, point.y, Color.Black))
                .Subscribe(o =>
            {
                Board.SetColor(new ColorPoint(o.x,o.y),Color.Black );
                Board.ReversiAllDirection(o.x, o.y, Color.Black);
                var board2 = Board.Board;
                Board.Board = board2;

                Player.ChangePlayer();
                if (!Board.IsContinue())
                {
                    navigationService.GoBack();
                }
                var AIcolorpoint = new IntelliGenceService(Board).GetShouldSetPoint(Color.White);
                Board.SetColor(new ColorPoint(AIcolorpoint.x, AIcolorpoint.y), Color.White);
            });

        }
    }
}
