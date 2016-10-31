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

        public event EventHandler<TappedRoutedEventArgs> BoardTapped;
        private static double FrameWidth = 8;
        private static double FrameHeight = 8;
        private readonly double _boardSize = 300 - (FrameWidth + FrameHeight);
        public double GetFramePosition(double basePosition) => (_boardSize / 8) * basePosition + FrameWidth;


        public void ReRendering()
        {
            Boardcanvas.Children.Clear();

            // 座標を置いたり、する帯を追加
            AddStroke(0, 0, 300, FrameHeight, Colors.Black);
            AddStroke(0, 0, FrameWidth, 300, Colors.Black);
            AddStroke(300 - FrameWidth, 0, FrameWidth, 300, Colors.Black);
            AddStroke(0, 300 - FrameHeight, 300, FrameHeight, Colors.Black);

            BanRenderring();
        }

        private void BanRenderring()
        {
            //X座標列を表示
            for (var i = 0; i < 8; i++)
            {
                AddLabel(GetFramePosition(i) + GetFramePosition(1) / 2.8, 0, Util.Int2Alphabet(i + 1));
            }
            //Y座標列を表示
            for (var i = 0; i < 8; i++)
            {
                AddLabel(3, GetFramePosition(i) + GetFramePosition(1) / 3.5, (i + 1).ToString());
            }

            var frameColor = Colors.Black;

            //枠を追加する
            for (int i = 1; i < 8; i++)
            {
                AddStroke(GetFramePosition(i), 8, 1, _boardSize, frameColor);
                AddStroke(8, GetFramePosition(i), _boardSize, 1, frameColor);
            }

            AddStone(GetFramePosition(2) - 2.5, GetFramePosition(2) - 2.5, frameColor, Width: 6, Height: 6);
            AddStone(GetFramePosition(2) - 2.5, GetFramePosition(6) - 2.5, frameColor, Width: 6, Height: 6);
            AddStone(GetFramePosition(6) - 2.5, GetFramePosition(2) - 2.5, frameColor, Width: 6, Height: 6);
            AddStone(GetFramePosition(6) - 2.5, GetFramePosition(6) - 2.5, frameColor, Width: 6, Height: 6);

            //駒を追加する
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
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
                        case Player.None:
                            //circle.Fill = new SolidColorBrush(Colors.DarkGreen);
                            break;
                    }
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
                Fill = new SolidColorBrush(color),
            };
            Canvas.SetLeft(stroke, x);
            Canvas.SetTop(stroke, y);
            Boardcanvas.Children.Add(stroke);
        }

        public void AddStone(double x, double y, Color color, double opacity = 1.0, int Width = 25, int Height = 25)
        {
            var circle = new Ellipse
            {
                Width = Width,
                Height = Height,
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