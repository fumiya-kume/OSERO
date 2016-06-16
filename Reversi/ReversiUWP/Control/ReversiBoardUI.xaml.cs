using ReversiUWP.classes;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ReversiUWP.Control
{
    public sealed partial class ReversiBoardUI : UserControl
    {
        private classes.Color[][] BboardColors;

        public classes.Color[][] BoardColors
        {
            get
            {
                return BboardColors;
            }
            set
            {
                BboardColors = value;
                ReRendering();
            }
        }

        public ReversiBoardUI()
        {
            this.InitializeComponent();
        }

        public void ReRendering()
        {
            //X軸の座標列を表示
            for (int i = 1; i < 8; i++)
            {
                var x = (300 / 8) * i;
                AddLabel(x, 5, i.ToString());
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var x = (300/8 ) * i + 20;
                    var y = (300/8 ) * j + 20;
                    AddStone(x, y, i, j);
                }
            }
        }

        private void AddLabel(int x,int y,string text)
        {
            var label = new TextBlock
            {
                Text = text
            };
            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, y);
            this.Boardcanvas.Children.Add(label);
        }

        private void AddStone(int x, int y, int i, int j)
        {
            var Circle = new Ellipse
            {
                Width = 20,
                Height = 20,
            };
            switch (BoardColors[i][j])
            {
                case classes.Color.Black:
                    Circle.Fill = new SolidColorBrush(Colors.Black);
                    break;
                case classes.Color.White:
                    Circle.Fill = new SolidColorBrush(Colors.White);
                    break;
                case classes.Color.None:
                    Circle.Fill = new SolidColorBrush(Colors.SkyBlue);
                    break;
                default:
                    break;
            }
            Canvas.SetLeft(Circle, x);
            Canvas.SetTop(Circle, y);
            this.Boardcanvas.Children.Add(Circle);
        }
    }
}
