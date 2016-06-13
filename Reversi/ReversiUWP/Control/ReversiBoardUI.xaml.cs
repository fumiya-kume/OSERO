using ReversiUWP.classes;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ReversiUWP.Control
{
    public sealed partial class ReversiBoardUI : UserControl
    {
        private Color[][] BboardColors;

        public Color[][] BoardColors
        {
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

        private void ReRendering()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var x = (10 + 10) * i + 1;
                    var y = (10 + 10) * j + 1;
                    AddStone(x, y);
                }
            }
        }

        private void AddStone(int x, int y)
        {
            var Circle = new Ellipse
            {
                Width = 10,
                Height = 10,
                Stroke = new SolidColorBrush(Windows.UI.Colors.Red)
            };
            Canvas.SetLeft(Circle, x);
            Canvas.SetTop(Circle, y);
            this.Boardcanvas.Children.Add(Circle);
        }
    }
}
