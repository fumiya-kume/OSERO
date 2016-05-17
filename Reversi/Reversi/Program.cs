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
                if (EnterCommand())
                {
                    Player.Change();
                }
                DumpBoard();
                if (!reversi.IsContinue()) break;

                Console.WriteLine($"Now Player is {Player.NowColor}");
                GC.Collect();
            }
            Console.WriteLine("Game is Finished !!");
        }

        public static bool EnterCommand()
        {
            Console.WriteLine("Please Input Command ");
            Console.WriteLine("Height:X Width:Y");
            Console.WriteLine("Example {X Position} {Y Position}");
            var ConsoleText = Console.ReadLine();
            //入力された文字が処理できない内容だったら処理を中断する
            if (string.IsNullOrWhiteSpace(ConsoleText)) return false;

            if (!IsNumeric((int)ConsoleText.First())) return false;
            if (!IsNumeric((int)ConsoleText.Last())) return false;

            int x;
            int.TryParse(ConsoleText.First().ToString(), out x);
            int y;
            int.TryParse(ConsoleText.Last().ToString(), out y);
            //有効な数字でない場合は処理を中断する
            if (!IsNumeric(x)) return false;
            if (!IsNumeric(y)) return false;

            var color = Player.NowColor;
            if (!reversi.SetColor(x, y, color)) return false;
            return true;
        }

        private static bool IsNumeric(int str)
        {
            if (str == 0) return true;
            if (str == 1) return true;
            if (str == 2) return true;
            if (str == 3) return true;
            if (str == 4) return true;
            if (str == 5) return true;
            if (str == 6) return true;
            if (str == 7) return true;
            if (str == 8) return true;
            return false;
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