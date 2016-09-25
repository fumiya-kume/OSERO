using System.Linq;
using System.Reactive.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Prism.Windows.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reversi.Util;
using static Reversi.Util.Int2AlphabetService;
using static Reversi.Util.Piece;

namespace Reversi.ViewModels
{
    public class GamePageViewModel : ViewModelBase
    {
        public BoardManager BoardManager { get; set; } = new BoardManager();


        public ReactiveProperty<string> UserText { get; set; }
        public ReactiveProperty<string> AIText { get; set; }
        public ReactiveProperty<string> Greeting { get; set; } = new ReactiveProperty<string>("Hello World");

        public GamePageViewModel()
        {
            UserText = BoardManager.ObserveProperty(manager => manager.GameBoard)
                .SelectMany(pieces => pieces).SelectMany(pieces => pieces)
                .Count(piece => piece == Black).Select(i => "User: " + i.ToString())
                .ToReactiveProperty();

            AIText = BoardManager.ObserveProperty(manager => manager.GameBoard)
                .SelectMany(pieces => pieces).SelectMany(pieces => pieces)
                .Count(piece => piece == White).Select(i => "AI: " + i.ToString())
                .ToReactiveProperty();
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

            var touchpositionX = -1;
            var touchpositionY = -1;
            
            for (int i = 0; i < 8; i++)
            {
                if (X < (300 / 9 * (i + 1)))
                {
                    touchpositionX = i;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (X < (300 / 9 * (i + 1)))
                {
                    touchpositionY = i;
                }
            }
            if(touchpositionY == -1 || touchpositionY == -1) return;
            

        }
    }
}
