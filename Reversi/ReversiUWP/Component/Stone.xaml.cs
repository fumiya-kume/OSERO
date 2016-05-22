using System;
using Windows.UI.Xaml.Controls;
using ReversiLib;
using static ReversiLib.Color;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ReversiUWP.Component
{
    public sealed partial class Stone : UserControl
    {
        public Color Color { get; set; } = None;

        public Stone( Color color)
        {
            this.InitializeComponent();
            Color = color;
        }

        public void Change()
        {
            Color = EnemyColor(Color);
        }

        public  Color EnemyColor(Color color)
        {
            switch (color)
            {
                case Black:
                    return White;
                case White:
                    return Black;
                case None:
                    return None;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }
    }
}
