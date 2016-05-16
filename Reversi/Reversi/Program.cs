using System;
using System.Linq;
using ReversiLib;

namespace Reversi
{
    public class Program
    {
        public static ReversiLib.Reversi reversi { get; set; } = new ReversiLib.Reversi();
        public static Player Player { get; set; } = new Player();

        private static void Main(string[] args)
        {
            reversi.Init();
            DumpBoard();
            while (true)
            {
                EnterCommand();
                DumpBoard();
                if (!reversi.IsContinue()) break;
                Player.Change();
                Console.WriteLine($"Now Player is {Player.NowColor}");
            }
            Console.WriteLine("Game is Finished !!");
        }

        public static void EnterCommand()
        {
            Console.WriteLine("Please Input Command ");
            Console.WriteLine("Height:X Width:Y");
            Console.WriteLine("Example {X Position} {Y Position}");
            var ConsoleText = Console.ReadLine();
            if (ConsoleText == null) return;
            int x;
            int.TryParse(ConsoleText.First().ToString(), out x);
            int y;
            int.TryParse(ConsoleText.Last().ToString(), out y);
            var color = Player.NowColor;
            if (reversi.SetColor(x, y, color)) ;
        }

        public static void DumpBoard()
        {
            var board = reversi.Board;
            Console.WriteLine(" 01234567");
            for (var i = 0; i < 8; i++)
            {
                Console.Write(i);
                var Text = "";
                for (var j = 0; j < 8; j++)
                {
                    Text = Text + Color2String(board[i][j]);
                }
                Console.WriteLine(Text);
            }
        }

        public static string Color2String(Color color)
        {
            switch (color)
            {
                case Color.Black:
                    return "*";
                case Color.White:
                    return "0";
                case Color.None:
                    return "-";
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }
    }
}