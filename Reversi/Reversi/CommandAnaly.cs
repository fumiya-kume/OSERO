using System.Linq;

namespace Reversi
{
    public class CommandAnaly
    {

        public static bool CheckCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command)) return false;
            if (command.Length != 2) return false;
            return true;
        }
    
        public static int ParseX(string command)
        {
            switch (command.First())
            {
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'r':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                default:
                    return -1;
            }
        }

        public static int ParseY(string command)
           => int.Parse(command.Last().ToString());

    }
}
