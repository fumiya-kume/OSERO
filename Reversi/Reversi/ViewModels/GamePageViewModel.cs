using System.Reactive.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Prism.Windows.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reversi.Util;
using static Reversi.Util.Int2AlphabetService;

namespace Reversi.ViewModels
{
    public class GamePageViewModel : ViewModelBase
    {
        public BoardManager BoardManager { get; set; } = new BoardManager();
        
        public ReactiveProperty<string> BlackPieceCount { get; set; }
        public ReactiveProperty<string> WhitePieceCount { get; set; }

        public GamePageViewModel()
        {
            BlackPieceCount = BoardManager.ObserveProperty(manager => manager.GameBoard.Pieces)
                .Cast<Piece>().Count(piece => piece == Piece.Black)
                .Select(i => i.ToString()).ToReactiveProperty();

            BlackPieceCount = BoardManager.ObserveProperty(manager => manager.GameBoard.Pieces)
                .Cast<Piece>().Count(piece => piece == Piece.White)
                .Select(i => i.ToString()).ToReactiveProperty();
        }

        public void CanvasLoaded(object o, RoutedEventArgs args)
        {
            var canvas = (Canvas)o;
            var GameBoardWidth = canvas.Width;
            var GameBoardHeight = canvas.Height;

            //X座標列を表示
            for (var i = 0; i < 7; i++)
            {
                var label = new TextBlock
                {
                    Text = Int2Alphabet(i)
                };
                Canvas.SetLeft(label, GameBoardWidth / 8 * (i + 1) + 10);
                Canvas.SetTop(label, 10);
                canvas.Children.Add(label);
            }

            //Y座標列を表示
            for (var i = 1; i < 8; i++)
            {
                var label = new TextBlock
                {
                    Text = i.ToString()
                };
                Canvas.SetLeft(label, 10);
                Canvas.SetTop(label, GameBoardHeight / 8 * i + 10);
                canvas.Children.Add(label);
            }
        }

        public void CanvasTapped(object obj, TappedRoutedEventArgs args)
        {
            var X = args.GetPosition((Canvas)obj).X;
            var Y = args.GetPosition((Canvas)obj).Y;


        }
    }
}
