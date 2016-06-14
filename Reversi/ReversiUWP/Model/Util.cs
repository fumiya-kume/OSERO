using System;
using ReversiUWP.classes;
using static ReversiUWP.classes.Color;

namespace ReversiUWP.Model
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