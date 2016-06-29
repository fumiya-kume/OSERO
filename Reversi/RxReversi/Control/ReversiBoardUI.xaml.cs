using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using RxReversi.Model;
using Color = RxReversi.classes.Color;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Reversi.Control
{
    public partial class ReversiBoardUI : UserControl
    {
        private Color[][] _boardColors;

        public ReversiBoardUI()
        {
            InitializeComponent();
        }

        public Color[][] BoardColors
        {
            get { return _boardColors; }
            set
            {
                _boardColors = value;
                ReRendering();
            }
        }

        public event EventHandler<TappedRoutedEventArgs> BoardTapped;

        public void ReRendering()
        {
            //X座標列を表示
            for (var i = 0; i < 8; i++)
            {
                var x = 300/9*i + 25;
                AddLabel(x, 0, Util.Int2Alphabet(i));
            }

            //Y座標列を表示
            for (var i = 1; i < 9; i++)
            {
                var y = 300/9*i - 15;
                AddLabel(10, y, i.ToString());
            }

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    var x = 300/9*i + 20;
                    var y = 300/9*j + 20;
                    AddStone(x, y, i, j);
                }
            }
        }

        private void AddLabel(int x, int y, string text)
        {
            var label = new TextBlock
            {
                Text = text
            };
            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, y);
            Boardcanvas.Children.Add(label);
        }

        private void AddStone(int x, int y, int i, int j)
        {
            var Circle = new Ellipse
            {
                Width = 20,
                Height = 20
            };
            switch (BoardColors[i][j])
            {
                case Color.Black:
                    Circle.Fill = new SolidColorBrush(Colors.Black);
                    break;
                case Color.White:
                    Circle.Fill = new SolidColorBrush(Colors.White);
                    break;
                case Color.None:
                    Circle.Fill = new SolidColorBrush(Colors.SkyBlue);
                    break;
                default:
                    break;
            }
            Canvas.SetLeft(Circle, x);
            Canvas.SetTop(Circle, y);
            Boardcanvas.Children.Add(Circle);
        }

        public virtual void OnBoardTapped(TappedRoutedEventArgs e)
        {
            var eventHandler = BoardTapped;
            eventHandler?.Invoke(this, e);
        }

        private void Boardcanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OnBoardTapped(e);
        }
    }
}