using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using  static ReversiUWP.classes.Color;
using Windows.UI.Xaml.Media;
using Color = ReversiUWP.classes.Color;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ReversiUWP.Control
{
    public sealed partial class Stone : UserControl
    {
        public Color color
        {
            get { return color; }
            set
            {
                color = value;
                changeColor();
            }
        }

        private void changeColor()
        {
            switch (color)
            {
                case Black:
                    this.Root.Background = new SolidColorBrush(Colors.Black);
                    break;
                case White:
                    this.Root.Background = new SolidColorBrush(Colors.White);
                    break;
                case None:
                    this.Root.Background = new SolidColorBrush(Colors.Green);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Stone()
        {
            this.InitializeComponent();
        }
    }
}
