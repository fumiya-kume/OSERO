namespace MilkCha.Util
{
    public static class Util
    {
        public static bool IsRange(int x, int y)
        {
            if (x < 0 || 7 < x) return false;
            if (y < 0 || 7 < y) return false;

            return true;
        }

        public static PlayerList EnemyColor(PlayerList player)
        {
            switch (player)
            {
                case PlayerList.Player:
                    return PlayerList.Cpu;
                case PlayerList.Cpu:
                    return PlayerList.Player;
                default:
                    return PlayerList.None;
            }
        }

        public static string Int2Alphabet(int i)
        {
            switch (i)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
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