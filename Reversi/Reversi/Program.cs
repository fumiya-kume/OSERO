using System;
using System.Linq;
using ReversiLib;
using static ReversiLib.Color;

namespace Reversi
{
    public class Program
    {
        public static Board board { get; set; } = new Board();
        public static ReversiLib.Reversi reversi { get; set; } = new ReversiLib.Reversi();
        public static Player Player { get; set; } = new Player();
        class EndOfGame : Exception { }

        private static void Main(string[] args)
        {
            Init();
            while (true)
            {
                //if (reversi.IsSkip()) { Player.Skip();}
                if (false) { Player.Skip(); }
                if (Player.SkipCounter == 2)
                {
                    CheckGameResult();
                    break;
                }
                try
                {
                    EnterCommand();
                }
                catch (EndOfGame)
                {
                    break;
                    throw;
                }
                DumpBoard();
            }
            Console.WriteLine("ゲームが終了しました。");
        }

        static void CheckGameResult()
        {
            if (board.CountWhiteColor() > board.CountBlackColor())
            {
                Console.WriteLine("白の勝利");
            }
            else if (board.CountWhiteColor() < board.CountBlackColor())
            {
                Console.WriteLine("黒の勝利");
            }
            else
            {
                Console.WriteLine("引き分け");
            }
        }

        static void Init()
        {
            board.Init();
            DumpBoard();
            EnterCommand();
            DumpBoard();
        }

        static void EnterCommand()
        {
            Console.WriteLine("コマンドを入力してください ");
            Console.WriteLine("例 c4");
            var consoleText = Console.ReadLine();
            if (consoleText == "Exit")
            {
                throw new EndOfGame();
            }

            try
            {
                var x = CommandAnaly.ParseX(consoleText);
                var y = CommandAnaly.ParseY(consoleText);
                y = y - 1;

                Console.WriteLine($"x:{x} y:{y}");
                reversi.SetColor(x, y, Player.NowColor);
                Player.Change();
            }
            catch (OverlapStone)
            {
                Console.WriteLine("その場所にはコマがすでに置かれています。");
            }
            catch (FormatException)
            {
                ShowErrorCommnad(consoleText);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("値の範囲を間違えています。");
            }
            catch (NotEnableSetStone)
            {
                Console.WriteLine("その場所にはコマを置けません");
            }
        }

        static void ShowErrorCommnad(string Command)
        {
            Console.WriteLine($"{Command} の値がおかしいです");
        }

        static void ShowNowTurn()
        {
            Console.WriteLine($"現在は{Player.NowColor}の色のターンです。");
        }

        static void DumpBoard()
        {
            var board = reversi.GetAllBoardData();
            Console.WriteLine(" ABCDEFGH");
            for (var i = 0; i < 8; i++)
            {
                var text = (i + 1) + board[i].Select(Color2String).Aggregate((j, j2) => j + j2);
                Console.WriteLine(text);
            }
            ShowNowTurn();
            Console.WriteLine($"Black:{Color2String(Black)} White:{Color2String(White)}");
        }

        public static string Color2String(Color color)
        {
            switch (color)
            {
                case Black:
                    return "*";
                case White:
                    return "0";
                case None:
                    return "-";
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }
    }
}