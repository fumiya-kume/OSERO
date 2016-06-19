using System;
using Reversi.classes;

namespace Reversi.Model
{
    public static class Util
    {
        public static bool IsRange(int x, int y)
        {
            if (x < 0 || 8 < x) return false;
            if (y < 0 || 8 < y) return false;

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