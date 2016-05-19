using System;
using System.Linq;
using System.Runtime.CompilerServices;
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
                Console.WriteLine($"Now Player is {Player.NowColor}");
                if (EnterCommand())
                    Player.Change();
                Console.WriteLine("");
                DumpBoard();
                if (!reversi.IsContinue()) break;
                GC.Collect();
            }
            Console.WriteLine("Game is Finished !!");
        }

        public static bool EnterCommand()
        {
            Console.WriteLine("Please Input Command ");
            Console.WriteLine("Example {X Position} {Y Position}");
            var consoleText = Console.ReadLine();
            //入力された文字が処理できない内容だったら処理を中断する
            if (string.IsNullOrWhiteSpace(consoleText))
            {
                Console.WriteLine("Command is Not Found.");
                return false;
            }
            int x;
            int y;
            try
            {
                x = ParseX(consoleText);
                y = ParseY(consoleText);
            }
            catch (FormatException)
            {
                OutputCommandError(consoleText);
                return false;
            }


            if (!IsRangeOfCommand(x) && !IsRangeOfCommand(y))
            {
                Console.WriteLine("Command is Out of Range.");
                return false;
            }

            try
            {
                if (!reversi.SetColor(x, y, Player.NowColor)) return false;
            }
            catch (OverlapStone)
            {
                Console.WriteLine("Overlap Stone !!");
                return false;
            }
            catch (NotEnableSetStone)
            {
                Console.WriteLine("Not Enable Set Stone");
                return false;
            }

            return true;
        }

        //値が範囲内か調べる
        public static bool IsRangeOfCommand(int value)
            => 0 <= value && value <= 8;

        //入力されたコマンドからXを取り出す
        public static int ParseX(string command)
            => int.Parse(command.Last().ToString());

        //入力されたコマンドからY を取り出す
        public static int ParseY(string command)
            => int.Parse(command.First().ToString());

        public static void OutputCommandError(string command)
            => Console.WriteLine($"\" {command} \" is Illegal value");

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
            Console.WriteLine($"Black:{Color2String(Color.Black)} White:{Color2String(Color.White)}");
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