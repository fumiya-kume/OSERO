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
            reversi.Board.Init();
            DumpBoard();
            Console.WriteLine($"現在のプレイヤーは、{Player.NowColor}");
            if (EnterCommand())
                Player.Change();
            DumpBoard();
            while (true)
            {
                Console.WriteLine($"現在のプレイヤーは、{Player.NowColor}");
                try
                {
                    if (reversi.IsSkip())
                    {
                        Player.Skip();
                        if (2 <= Player.SkipCounter)
                        {
                            if (reversi.Board.CountWhiteColor() > reversi.Board.CountBlackColor())
                            {
                                Console.WriteLine("白の勝ちです");
                            }
                            else if (reversi.Board.CountWhiteColor() < reversi.Board.CountBlackColor())
                            {
                                Console.WriteLine("黒の勝ちです");
                            }
                            else
                            {
                                Console.WriteLine("引き分けです");
                            }
                            break;
                        }
                    }
                    else
                    {

                        if (EnterCommand())
                            Player.Change();
                    }
                }
                catch (Exception)
                {
                    break;
                }
                Console.WriteLine("");
                DumpBoard();
                if (!reversi.IsContinue()) break;
            }
            Console.WriteLine("ゲームが終了しました。");
        }

        public static bool EnterCommand()
        {
            Console.WriteLine("コマンドを入力してください ");
            Console.WriteLine("例 c4");
            var consoleText = Console.ReadLine();
            //入力された文字が処理できない内容だったら処理を中断する
            if (string.IsNullOrWhiteSpace(consoleText))
            {
                Console.WriteLine("コマンドが存在しません");
                return false;
            }
            if (consoleText == "Exit")
                throw new Exception();
            if (consoleText.Length != 2)
            {
                OutputCommandError(consoleText);
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
                Console.WriteLine("コマンドの値が異常です");
                return false;
            }

            try
            {
                if (!reversi.Board.SetColor(x, y, Player.NowColor)) return false;
            }
            catch (OverlapStone)
            {
                Console.WriteLine("すでに石が存在しています");
                return false;
            }
            catch (NotEnableSetStone)
            {
                Console.WriteLine("石をセットすることができません");
                return false;
            }

            return true;
        }

        //値が範囲内か調べる
        public static bool IsRangeOfCommand(int value)
            => 0 <= value && value <= 8;

        //入力されたコマンドからXを取り出す
        public static int ParseY(string command)
        {
            Console.WriteLine(command.First());
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
        //=> int.Parse(command.Last().ToString());

        //入力されたコマンドからY を取り出す
        public static int ParseX(string command)
            => int.Parse(command.Last().ToString());

        public static void OutputCommandError(string command)
            => Console.WriteLine($"\" {command} \"のコマンドがおかしいです");

        public static void DumpBoard()
        {
            var board = reversi.Board.Board;
            Console.WriteLine(" abcdefgh");
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
            Console.WriteLine($"White:{reversi.Board.CountWhiteColor()} Black:{reversi.Board.CountBlackColor()}");
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