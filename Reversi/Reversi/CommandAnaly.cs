using System.Linq;

namespace Reversi
{
    public class CommandAnaly
    {
        public string CommandText { get; set; }

        public CommandAnaly(string command)
        {
            CommandText = command;
        }

        public bool CheckCommand()
        {
            if (string.IsNullOrWhiteSpace(CommandText)) return false;
            if (CommandText.Length != 2) return false;
            return true;
        }
    
        public int ParseX()
        {
            switch (CommandText.First())
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

        public int ParseY()
           => int.Parse(CommandText.Last().ToString());

    }
}
