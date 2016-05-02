using System;
using System.Linq;
using Reversi;

namespace ConsoleApplication1
{
    class Program
    {
        public static ReversiLib reversilib { get; set; } = new ReversiLib();

        private static void Main(string[] args)
        {
            Console.WriteLine("Game Start");
            BoardInit();
            DumpBoard();
            while (true)
            {
                if (IsContinue()) break;
                PutStone(Stone.StoneColorList.Black);
                DumpBoard();
            }
            Console.WriteLine("Game Finish");

        }

        private static void PutStone(Stone.StoneColorList color)
        {
            Console.WriteLine("石の場所を指定してください:x y range = 0-8");
            var readLine = Console.ReadLine();
            //石の場所を指定していない場合の対処
            if (string.IsNullOrEmpty(readLine) || string.IsNullOrWhiteSpace(readLine)) return;

            //最初から１番目の文字を取得
            int pointX;
            if (!int.TryParse(readLine.Substring(0, 1), out pointX)) return;

            //最後から２番めの文字を取得
            int pointY;
            if (!int.TryParse(readLine.Substring(readLine.Length - 1, 1), out pointY)) return;

            Console.WriteLine($"X:{pointX}Y:{pointY}");

            reversilib.PutStone(new Stone { X = pointX, Y = pointY, StoneColor = color });
        }

        private static bool IsContinue()
        {
            var whiteStone = 0;
            var blacStone = 0;
            for (var i = 0; i < 8; i++)
            {
                whiteStone = reversilib.Board[i]
                    .Count(stone => stone.StoneColor == Stone.StoneColorList.White);
                blacStone = reversilib.Board[i]
                    .Count(stone => stone.StoneColor == Stone.StoneColorList.Black);
            }
            if (whiteStone == 0 || blacStone == 0) return false;
            return true;

        }


        public static void BoardInit()
        {
            reversilib.PutStone(new Stone { X = 3, Y = 4, StoneColor = Stone.StoneColorList.Black });
            reversilib.PutStone(new Stone { X = 4, Y = 3, StoneColor = Stone.StoneColorList.Black });
            reversilib.PutStone(new Stone { X = 4, Y = 4, StoneColor = Stone.StoneColorList.White });
            reversilib.PutStone(new Stone { X = 3, Y = 3, StoneColor = Stone.StoneColorList.White });
        }

        public static void DumpBoard()
        {
            Console.WriteLine(" １２３４５６７８");
            for (var i = 0; i < 8; i++)
            {
                Console.Write(i + 1);

                foreach (var nowStone in reversilib.Board[i])
                {
                    Console.Write(Stone2String(nowStone));
                }
                Console.WriteLine(" ");
            }

        }

        public static string Stone2String(Stone stone)
        {
            switch (stone.StoneColor)
            {
                case Stone.StoneColorList.None:
                    return "ー";
                case Stone.StoneColorList.White:
                    return "○";
                case Stone.StoneColorList.Black:
                    return "＊";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
