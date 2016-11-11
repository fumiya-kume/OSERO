using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Reversi.classes;
using Reversi.Model;
using Player = Reversi.classes.Player;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Reversi.Control
{
    public partial class ReversiBoardUI : UserControl
    {
        private ColorData _beforeInputColor;

        public ReversiBoardUI()
        {
            InitializeComponent();
        }

        public Player[][] BoardPlayers { private get; set; }

        public List<ColorPoint> EnableColorPointList { private get; set; }

        public ColorData BeforeInputColor
        {
            get { return _beforeInputColor; }
            set
            {
                _beforeInputColor = value;
                var circle = new Ellipse
                {
                    Width = 7,
                    Height = 7,
                    Fill = new SolidColorBrush(Colors.DarkGreen)
                };
                var x = GetFramePosition(value.point.x);
                var y = GetFramePosition(value.point.y);
                Canvas.SetLeft(circle, x);
                Canvas.SetTop(circle, y);
                Boardcanvas.Children.Add(circle);
            }
        }

        private double FrameWidth => 8;
        private double FrameHeight => 8;
        public int SquareSideCount { get; set; } = 8;
        public int SquareVerticalCount { get; set; } = 8;
        public double BoardSize => Boardcanvas.Width;
        public double BoardWidth => Boardcanvas.Width;
        public double BoardHeight => Boardcanvas.Height;
        public double FrameSize => Boardcanvas.Width - (FrameWidth + FrameHeight);
        public int SmallVertivalMidPoint => SquareVerticalCount/2 - 2;
        public int SmallSideMidPoint => SquareSideCount/2 - 2;
        public int BigVerticalMidPoint => SquareVerticalCount/2 + 2;
        public int BigSideMidPoint => SquareSideCount/2 + 2;
        public int MidStoneWidth => 6;
        public int MidStoneHeight => 6;

        public event EventHandler<TappedRoutedEventArgs> BoardTapped;
        public double GetFramePosition(double basePosition) => FrameSize/8*basePosition + FrameWidth;


        public void ReRendering()
        {
            Boardcanvas.Children.Clear();

            var frameColor = Colors.Black;

            for (var i = 0; i < SquareVerticalCount; i++)
                AddStroke(8, GetFramePosition(i), FrameSize, 1, frameColor);

            for (var i = 0; i < SquareSideCount; i++)
                AddStroke(GetFramePosition(i), 8, 1, FrameSize, frameColor);

            AddStone(GetFramePosition(SmallVertivalMidPoint) - 2.5, GetFramePosition(SmallSideMidPoint) - 2.5,
                frameColor, width: MidStoneWidth, height: MidStoneHeight);
            AddStone(GetFramePosition(SmallVertivalMidPoint) - 2.5, GetFramePosition(BigSideMidPoint) - 2.5, frameColor,
                width: MidStoneWidth, height: MidStoneHeight);
            AddStone(GetFramePosition(BigVerticalMidPoint) - 2.5, GetFramePosition(SmallSideMidPoint) - 2.5, frameColor,
                width: MidStoneWidth, height: MidStoneHeight);
            AddStone(GetFramePosition(BigVerticalMidPoint) - 2.5, GetFramePosition(BigSideMidPoint) - 2.5, frameColor,
                width: MidStoneWidth, height: MidStoneHeight);

            // 縁の内側の線
            var frameShadow = Color.FromArgb(byte.MaxValue, 32, 32, 32);
            AddStroke(FrameWidth, FrameHeight, FrameSize, 1, frameShadow);
            AddStroke(FrameWidth, FrameHeight + FrameSize - 1, FrameSize, 1, frameShadow);
            AddStroke(FrameWidth, FrameHeight, 1, FrameSize, frameShadow);
            AddStroke(FrameWidth + FrameSize - 1, FrameHeight, 1, FrameSize, frameShadow);

            // 座標を置いたり、する帯を追加
            AddStroke(0, 0, BoardSize, FrameHeight, Colors.Black);
            AddStroke(0, 0, FrameWidth, BoardSize, Colors.Black);
            AddStroke(BoardSize - FrameWidth, 0, FrameWidth, BoardSize, Colors.Black);
            AddStroke(0, BoardSize - FrameHeight, BoardSize, FrameHeight, Colors.Black);

            // 縁の外側の線
            AddStroke(0, 0, 1, BoardSize, frameShadow);
            AddStroke(0, 0, BoardSize, 1, frameShadow);
            AddStroke(0, BoardSize - 1, BoardSize, 1, frameShadow);
            AddStroke(BoardSize - 1, 0, 1, BoardSize, frameShadow);

            BanRenderring();
        }

        private void BanRenderring()
        {
            //X座標列を表示
            for (var i = 0; i < SquareSideCount; i++)
                AddLabel(GetFramePosition(i) + GetFramePosition(1)/2.8, 0, Util.Int2Alphabet(i + 1));
            //Y座標列を表示
            for (var i = 0; i < SquareVerticalCount; i++)
                AddLabel(3, GetFramePosition(i) + GetFramePosition(1)/3.5, (i + 1).ToString());

            //駒を追加する
            for (var i = 0; i < SquareVerticalCount; i++)
                for (var j = 0; j < SquareSideCount; j++)
                {
                    var x = GetFramePosition(0.18 + i);
                    var y = GetFramePosition(0.18 + j);
                    x--;
                    y--;
                    switch (BoardPlayers[i][j])
                    {
                        case Player.Black:
                            AddStone(x + 0.5, y + 0.5, Colors.White);
                            AddStone(x, y, Colors.Black);
                            break;
                        case Player.White:
                            AddStone(x + 1.5, y + 1.5, Colors.Black);
                            AddStone(x, y, Colors.LightGray);
                            break;
                    }
                }

            //置ける駒を表示
            EnableColorPointList.ForEach(point =>
            {
                var x = GetFramePosition(0.38 + point.x);
                var y = GetFramePosition(0.38 + point.y);
                AddStone(x, y, Colors.White, 0.5, 10, 10);
            });
        }

        private void AddLabel(double x, double y, string text)
        {
            var label = new TextBlock
            {
                Text = text,
                FontSize = 6,
                Foreground = new SolidColorBrush(Colors.White)
            };
            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, y);
            Boardcanvas.Children.Add(label);
        }

        private void AddStroke(double x, double y, double width, double height, Color color)
        {
            var stroke = new Rectangle
            {
                Height = height,
                Width = width,
                Fill = new SolidColorBrush(color)
            };
            Canvas.SetLeft(stroke, x);
            Canvas.SetTop(stroke, y);
            Boardcanvas.Children.Add(stroke);
        }

        public void AddStone(double x, double y, Color color, double opacity = 1.0, int width = 25, int height = 25)
        {
            var circle = new Ellipse
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(color),
                Opacity = opacity
            };
            Canvas.SetLeft(circle, x);
            Canvas.SetTop(circle, y);
            Boardcanvas.Children.Add(circle);
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