using Windows.Foundation;
using RxReversi.classes;
using static Windows.UI.Xaml.Window;

namespace RxReversi.Services
{
    public static class Position2PointService
    {
        public static ColorPoint Translate(Point point,double BoardWidth,double BoardHeight)
        {
            var x = 0;
            var y = 0;

            for (int i = 0; i < 8; i++)
            {
                if (300/9*i + 20 < BoardWidth && BoardWidth < 300/9*i + 1 + 20)
                {
                    x = i;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (300 / 9 * i + 20 < BoardHeight && BoardHeight < 300 / 9 * i + 1 + 20)
                {
                    y= i;
                }
            }
            return new ColorPoint {x = (int) x, y = (int) y};
        }
    }
}
