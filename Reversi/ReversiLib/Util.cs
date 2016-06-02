using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ReversiLib.Color;
using System.Threading.Tasks;

namespace ReversiLib
{
    public class Util
    {
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
