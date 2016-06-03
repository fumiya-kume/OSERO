using System;
using ReversiUWP.classes;
using static ReversiUWP.classes.Color;

namespace ReversiUWP.Model
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