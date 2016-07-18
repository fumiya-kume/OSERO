using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using RxReversi.classes;
using RxReversi.Model;
using RxReversi.Services;
using Color = RxReversi.classes.Color;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace RxReversi.Control
{
    public partial class ReversiBoardUi : UserControl
    {
        public ReversiBoardUi()
        {
            InitializeComponent();
            //(Content as FrameworkElement) = this;
        }

        public static readonly DependencyProperty BoardColorsProperty = DependencyProperty.Register(
            "BoardColors",
            typeof(Color[][]),
            typeof(ReversiBoardUi),
            new PropertyMetadata(string.Empty, (o, args) =>
            {
                ((ReversiBoardUi) o).BoardColors = (Color[][])args.NewValue;
                ((ReversiBoardUi) o).ReRendering();
            }));

        public Color[][] BoardColors
        {
            get { return (Color[][])GetValue(BoardColorsProperty); }
            set
            {
                SetValue(BoardColorsProperty, value);
                ReRendering();
            }
        }

        public void ReRendering()
        {
            var width = (int)Width;
            var height = (int)Height;
            //X座標列を表示
            for (var i = 0; i < 8; i++)
            {
                var x = ColorPoint2PointService.ConvertX(width, i);
                AddLabel(x, 0, Util.Int2Alphabet(i));
            }

            //Y座標列を表示
            for (var i = 0; i < 8; i++)
            {
                var y = ColorPoint2PointService.ConvertY(height, i);
                AddLabel(10, y, (i + 1).ToString());
            }

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    AddStone(ColorPoint2PointService.Convert(width, height, i, j), i, j);
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

        private void AddStone(Point point, int i, int j)
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
            }
            Canvas.SetLeft(Circle, point.X);
            Canvas.SetTop(Circle, point.Y);
            Boardcanvas.Children.Add(Circle);
        }

        public delegate void BoardTappedHandler(object sender, BoardTappedArgs cla);
        public event BoardTappedHandler Changed;
        private void Boardcanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var result = ColorPoint2PointService.ReConvert(e.GetPosition(this), (int)Width, (int)Height);

            Changed?.Invoke(this, new BoardTappedArgs(result));
        }
    }

    public class BoardTappedArgs:EventArgs
    {
        public ColorPoint ColorPoint { get; set; }

        public BoardTappedArgs(ColorPoint colorPoint)
        {
            ColorPoint = colorPoint;
        }
    }
}