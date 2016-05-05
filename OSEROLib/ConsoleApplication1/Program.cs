using System;
using System.Linq;
using System.Threading;
using Reversi;

namespace ConsoleApplication1
{
    class Program
    {
        public static ReversiLib Reversilib { get; set; } = new ReversiLib();

        private static void Main(string[] args)
        {
            Console.WriteLine("Game Start");
            BoardInit();
            DumpBoard();

            while (Reversilib.IsContinue())
            {
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
            if (string.IsNullOrWhiteSpace(readLine)) return false;
            int pointX = int.Parse(readLine.First().ToString());
            int pointY = Int32.Parse(readLine.Last().ToString());
            Console.WriteLine($"X:{pointX}Y:{pointY}");

            return Reversilib.SetStone(new Stone { X = pointX - 1, Y = pointY - 1, StoneColor = color });
        }
        
        static void BoardInit()
        {
            Reversilib.SetStone(new Stone { X = 3, Y = 4, StoneColor = Stone.StoneColorList.Black });
            Reversilib.SetStone(new Stone { X = 4, Y = 3, StoneColor = Stone.StoneColorList.Black });
            Reversilib.SetStone(new Stone { X = 4, Y = 4, StoneColor = Stone.StoneColorList.White });
            Reversilib.SetStone(new Stone { X = 3, Y = 3, StoneColor = Stone.StoneColorList.White });
        }

        public static void DumpBoard()
        {
            Console.WriteLine(" １２３４５６７８");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i + 1);

                Console.Write(Reversilib.ReversiBoard.Board[i].Select(S2S).Aggregate((stone, stone1) => stone + stone1));

                Console.WriteLine(" ");
            }
        }

        public static string S2S(Stone stone)
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
