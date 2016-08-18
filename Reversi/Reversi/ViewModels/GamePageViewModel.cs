using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Prism.Windows.Mvvm;
using Reversi.Model;
using static Reversi.Util.Int2AlphabetService;

namespace Reversi.ViewModels
{
    public class GamePageViewModel : ViewModelBase
    {
        public BoardManager BoardManager { get; set; } = new BoardManager();



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
