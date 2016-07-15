using System.Diagnostics;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using RxReversi.classes;

namespace RxReversi.Services
{
    public static class ColorPoint2PointService
    {
        public static Point Convert(int width, int height, int xCount, int yCount)
            => new Point()
            {
                X = width / 9 * (xCount + 1),
                Y = height / 9 * (yCount + 1)
            };

        public static ColorPoint ReConvert(Point point, int width, int height)
        {
            var x = -1;
            var y = -1;

            for (int i = 0; i < 8; i++)
            {
                if (width / 9 * (i + 1) - 10 < point.X && point.X < width / 9 * (i + 1) + 10)
                {
                    x = i;
                }
                if (height / 9 * (i + 1) - 10 < point.Y && point.Y < height / 9 * (i + 1) + 10)
                {
                    y = i;
                }
            }
            Debug.Write($"point.x:{point.X} => {x}\npoint.y:{point.Y}=>{y}\n\n");
            return new ColorPoint(x, y);
        }

        public static int ConvertX(int width, int xCount)
        {
            return (int)Convert(width, 0, xCount, 0).X;
        }

        public static int ConvertY(int height, int yCount)
        {
            return (int)Convert(0, height, 0, yCount).Y;
        }
    }
}
