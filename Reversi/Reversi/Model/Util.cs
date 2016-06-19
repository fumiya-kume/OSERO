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

        public static string Int2Alphabet(int i)
        {
            switch (i)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                default:
                    return string.Empty;
            }
        }

        public static int Alphabet2Int(string text)
        {
            switch (text)
            {
                case "A":
                    return 0;
                case "B":
                    return 1;
                case "C":
                    return 2;
                case "D":
                    return 3;
                case "E":
                    return 4;
                case "F":
                    return 5;
                case "G":
                    return 6;
                case "H":
                    return 7;
                default:
                    return -1;
            }
        }
    }
}