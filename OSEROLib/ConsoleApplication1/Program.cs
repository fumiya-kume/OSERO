using System;
using System.Linq;
using System.Threading;
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
                if (!reversilib.IsContinue()) break;
                if (PutStone(Stone.StoneColorList.Black)) Console.WriteLine("石を置けませんでした");

                DumpBoard();
                
            }
            Console.WriteLine("Game Finish");
            Thread.Sleep(3000); 
        }


        static bool PutStone(Stone.StoneColorList color)
        {
            Console.WriteLine("石の場所を指定してください:x y range = 0-8");
            var readLine = Console.ReadLine();
            //石の場所を指定していない場合の対処
            if (string.IsNullOrWhiteSpace(readLine)) return false;

            //最初から１番目の文字を取得
            int pointX;
            if (!int.TryParse(readLine.Substring(0, 1), out pointX)) return false;

            //最後から２番めの文字を取得
            int pointY;
            if (!int.TryParse(readLine.Substring(readLine.Length - 1, 1), out pointY)) return false;

            Console.WriteLine($"X:{pointX}Y:{pointY}");

            if (!reversilib.SetStone(new Stone { X = pointX-1, Y = pointY-1, StoneColor = color })) return false;

            return true;
        }


        static void BoardInit()
        {
            reversilib.SetStone(new Stone { X = 3, Y = 4, StoneColor = Stone.StoneColorList.Black });
            reversilib.SetStone(new Stone { X = 4, Y = 3, StoneColor = Stone.StoneColorList.Black });
            reversilib.SetStone(new Stone { X = 4, Y = 4, StoneColor = Stone.StoneColorList.White });
            reversilib.SetStone(new Stone { X = 3, Y = 3, StoneColor = Stone.StoneColorList.White });
        }

        public static void DumpBoard()
        {
            Console.WriteLine(" １２３４５６７８");
            for (int i = 0; i < 8; i++)
            {
                Console.Write( i + 1);
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(Stone2String(reversilib.ReversiBoard.GetStone(i, j)));
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
