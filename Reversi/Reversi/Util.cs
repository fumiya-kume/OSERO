using System;
using ReversiLib;

namespace Reversi
{
    public class Util
    {
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
