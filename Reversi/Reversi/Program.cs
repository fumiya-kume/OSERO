using System;
using System.Linq;
using ReversiLib;
using static ReversiLib.Color;

namespace Reversi
{
    public class Program
    {
        public static ReversiLib.Reversi reversi { get; set; } = new ReversiLib.Reversi();
        public static Player Player { get; set; } = new Player();
        class EndOfGame : Exception { }

        private static void Main(string[] args)
        {
            Init();
            while (true)
            {
                if (reversi.IsSkip())
                    Player.Skip();
                if (Player.SkipCounter >= 2)
                {
                    CheckGameResult();
                    break;
                }
                EnterCommand();
                DumpBoard();
            }
            Console.WriteLine("ゲームが終了しました。");
        }

        static void CheckGameResult()
        {
            if (reversi.CountWhiteColor() > reversi.CountBlackColor())
            {
                Console.WriteLine("白の勝利");
            }
            else if (reversi.CountWhiteColor() < reversi.CountBlackColor())
            {
                Console.WriteLine("黒の勝利");
            }
            else
            {
                Console.WriteLine("引き分け");
            }
        }

        private static void Init()
        {
            reversi.Init();
            DumpBoard();
            Console.WriteLine("コマンドを入力してください ");
            Console.WriteLine("例 C 4");
            EnterCommand();
        }

        static void EnterCommand()
        {
            var consoleText = Console.ReadLine();
            Console.WriteLine("コマンドを入力してください ");
            Console.WriteLine("例 C 4");
            if (string.IsNullOrWhiteSpace(consoleText))
            {
                Console.WriteLine("コマンドが存在しません");
                return;
            }
            
            if (consoleText == "Exit")
            {
                throw new EndOfGame();
            }
            //コマンドの長さがおかしい場合
            if (consoleText.Length < 4 || consoleText.Length < 3)
            {
                ShowErrorCommnad(consoleText);
                return;
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
                ShowErrorCommnad(consoleText);
                return;
            }

            try
            {
                reversi.SetColor(x, y, Player.NowColor);
                Player.Change();
            }
            catch (IndexOutOfRangeException)
            {
                ShowErrorCommnad(consoleText);
            }
            catch (OverlapStone)
            {
                Console.WriteLine("その場所には石がすでに置かれています。");
            }
            catch (NotEnableSetStone)
            {
                ShowErrorCommnad(consoleText);
            }
        }

        static void ShowErrorCommnad(string Command)
        {
            Console.WriteLine($"{Command} の値がおかしいです");
        }

        public static int ParseY(string consoleText)
            => int.Parse(consoleText.Last().ToString());

        public static int ParseX(string command)
        {
            switch (command.First())
            {
                case 'A':
                    return 0;
                case 'B':
                    return 1;
                case 'C':
                    return 2;
                case 'D':
                    return 3;
                case 'E':
                    return 4;
                case 'F':
                    return 5;
                case 'G':
                    return 6;
                case 'H':
                    return 7;
                default:
                    throw new FormatException();
            }
        }

        static void DumpBoard()
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

        //    private static void Main(string[] args)
        //    {
        //        reversi.Init();
        //        DumpBoard();
        //        Console.WriteLine($"現在のプレイヤーは、{Player.NowColor}");
        //        if (EnterCommand())
        //            Player.Change();
        //        while (true)
        //        {
        //            Console.WriteLine($"現在のプレイヤーは、{Player.NowColor}");
        //            try
        //            {
        //                if (!reversi.IsSkip())
        //                {
        //                    if (EnterCommand())
        //                        Player.Change();
        //                }
        //                else
        //                {
        //                    Player.Skip();
        //                    if(2 <= Player.SkipCounter)
        //                    {
        //                        if (reversi.CountWhiteColor() > reversi.CountBlackColor())
        //                        {
        //                            Console.WriteLine("白の勝ちです");
        //                        }
        //                        else if(reversi.CountWhiteColor() < reversi.CountBlackColor())
        //                        {
        //                            Console.WriteLine("黒の勝ちです");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("引き分けです");
        //                        }
        //                        break;
        //                    }
        //                }
        //            }
        //            catch (Exception)
        //            {
        //               break;
        //            }
        //            Console.WriteLine("");
        //            DumpBoard();
        //            Console.WriteLine($"White:{reversi.CountWhiteColor()} Black:{reversi.CountBlackColor()}");
        //            if (!reversi.IsContinue()) break;
        //        }
        //        Console.WriteLine("ゲームが終了しました。");
        //    }

        //    public static bool EnterCommand()
        //    {
        //        Console.WriteLine("コマンドを入力してください ");
        //        Console.WriteLine("例 C 4");
        //        var consoleText = Console.ReadLine();
        //        //入力された文字が処理できない内容だったら処理を中断する
        //        if (string.IsNullOrWhiteSpace(consoleText))
        //        {
        //            Console.WriteLine("コマンドが存在しません");
        //            return false;
        //        }
        //        if(consoleText == "Exit")
        //            throw new Exception();
        //        if (consoleText.Length > 3)
        //        {
        //            OutputCommandError(consoleText);
        //            return false;
        //        }
        //        int x;
        //        int y;
        //        try
        //        {
        //            x = ParseX(consoleText);
        //            y = ParseY(consoleText);
        //        }
        //        catch (FormatException)
        //        {
        //            OutputCommandError(consoleText);
        //            return false;
        //        }


        //        if (!IsRangeOfCommand(x) && !IsRangeOfCommand(y))
        //        {
        //            Console.WriteLine("コマンドの値が異常です");
        //            return false;
        //        }

        //        try
        //        {
        //            if (!reversi.SetColor(x, y, Player.NowColor)) return false;
        //        }
        //        catch (OverlapStone)
        //        {
        //            Console.WriteLine("すでに石が存在しています");
        //            return false;
        //        }
        //        catch (NotEnableSetStone)
        //        {
        //            Console.WriteLine("石をセットすることができません");
        //            return false;
        //        }

        //        return true;
        //    }

        //    //値が範囲内か調べる
        //    public static bool IsRangeOfCommand(int value)
        //        => 0 <= value && value <= 7;

        //    //入力されたコマンドからXを取り出す
        //    public static int ParseX(string command)
        //    {
        //        switch (command)
        //        {
        //            case "A":
        //                return 0;
        //            case "B":
        //                return 1;
        //            case "C":
        //                return 2;
        //            case "D":
        //                return 3;
        //            case "E":
        //                return 4;
        //            case "F":
        //                return 5;
        //            case "G":
        //                return 6;
        //            case "H":
        //                return 7;
        //            default:
        //                throw new FormatException();
        //        }
        //    }

        //    //入力されたコマンドからY を取り出す
        //    public static int ParseY(string command)
        //        => int.Parse(command.First().ToString());

        //    public static void OutputCommandError(string command)
        //        => Console.WriteLine($"\" {command} \"のコマンドがおかしいです");

        //    public static void DumpBoard()
        //    {
        //        var board = reversi.Board;
        //        Console.WriteLine(" 01234567");
        //        for (var i = 0; i < 8; i++)
        //        {
        //            Console.Write(i);

        //            var Text = "";
        //            for (var j = 0; j < 8; j++)
        //            {
        //                Text = Text + Color2String(board[i][j]);
        //            }
        //            Console.WriteLine(Text);
        //        }
        //        Console.WriteLine($"Black:{Color2String(Color.Black)} White:{Color2String(Color.White)}");
        //    }

        //    public static string Color2String(Color color)
        //    {
        //        switch (color)
        //        {
        //            case Color.Black:
        //                return "*";
        //            case Color.White:
        //                return "0";
        //            case Color.None:
        //                return "-";
        //            default:
        //                throw new ArgumentOutOfRangeException(nameof(color), color, null);
        //        }
        //    }
    }
}