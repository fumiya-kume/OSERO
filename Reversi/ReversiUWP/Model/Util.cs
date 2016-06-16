using System;
using ReversiUWP.classes;
using static System.String;
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

        public static string int2Alphabet(int i)
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
                    return Empty;
            }
        }

        public static int Alphabet2int(string text)
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