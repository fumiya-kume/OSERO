using Windows.Foundation;
using RxReversi.classes;
using static Windows.UI.Xaml.Window;
using System.Diagnostics;

namespace RxReversi.Services
{
    public static class Position2PointService
    {
        public static ColorPoint Translate(Point point, double BoardWidth, double BoardHeight)
        {
            var x = 0;
            var y = 0;

            Debug.Write($"Point\nX:{point.X}\nY:{point.Y}\n");
            Debug.Write($"Width:{BoardWidth}\nHeight{BoardHeight}\n");
            Debug.Write($"Current X:{Current.Bounds.X} \nY{Current.Bounds.Y}\n");

            TranslateX(point.X, BoardWidth);
            TranslateY(point.Y, BoardHeight);
            
            return new ColorPoint(x,y);
        }

        private static int TranslateX(double XPoint, double BoardWidth)
        {
            for (int i = 0; i < 8; i++)
            {
                if (XPoint < (BoardWidth / 9 * (i + 1)))
                {
                    return i;
                }
            }
            return -1;
        }

        private static int TranslateY(double YPoint, double BoardHeight)
        {
            for (int i = 0; i < 8; i++)
            {
                if (YPoint < (BoardHeight / 9 * (i + 1)))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
