using System;

namespace ReversiLib
{
    public class Util
    {
        public static bool IsRange(int x, int y)
        {
            if (x < 0 || x > 8) return false;
            if (y < 0 || y > 8) return false;

            return true;
        }

        public static Color EnemyColor(Color color)
        {
            switch (color)
            {
                case Color.Black:
                    return Color.White;
                case Color.White:
                    return Color.Black;
                case Color.None:
                    return Color.None;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }
    }
}