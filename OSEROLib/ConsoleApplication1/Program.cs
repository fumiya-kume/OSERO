using System;
using System.Linq;
using Reversi;
using static Reversi.StoneColorList;

namespace ConsoleApplication1
{
    class Program
    {
        //public static ReversiLib Reversilib { get; set; } = new ReversiLib();
        //private static StoneColorList Turn { get; set; } = White;
        //private static void SwitchTurn() => Turn = Turn == White ? Black : White;

        private static void Main()
        {
        //    Console.WriteLine("Game Start");
        //    BoardInit();
        //    DumpBoard();

        //    while (Reversilib.IsContinue())
        //    {
        //        if (SetStone(Turn)) SwitchTurn();
        //        DumpBoard();
        //    }

        //    Console.WriteLine("Game Finish");
        //    Console.ReadLine();
        //}


        //static bool SetStone(StoneColorList color)
        //{
        //    Console.WriteLine("石の場所を指定してください:{たて} {よこ} range = 0-8");
        //    var readLine = Console.ReadLine();
        //    if (string.IsNullOrWhiteSpace(readLine)) return false;
        //    var pointX = int.Parse(readLine.First().ToString());
        //    var pointY = int.Parse(readLine.Last().ToString());
        //    Console.WriteLine($"X:{pointX}Y:{pointY}");

        //    return Reversilib.SetStone(new Stone { X = pointX - 1, Y = pointY - 1, StoneColor = color });
        //}

        //static void BoardInit()
        //{
        //    Reversilib.SetStone(new Stone { X = 3, Y = 4, StoneColor = Black });
        //    Reversilib.SetStone(new Stone { X = 4, Y = 3, StoneColor = Black });
        //    Reversilib.SetStone(new Stone { X = 4, Y = 4, StoneColor = White });
        //    Reversilib.SetStone(new Stone { X = 3, Y = 3, StoneColor = White });
        //}

        //public static void DumpBoard()
        //{
        //    Console.WriteLine(" １２３４５６７８");
        //    for (var i = 0; i < 8; i++)
        //    {
        //        Console.Write(i + 1);
        //        Console.Write(Reversilib.ReversiBoard.Board[i].Select(S2S).Aggregate((stone, stone1) => stone + stone1));
        //        Console.WriteLine(" ");
        //    }
        //}

        //public static string S2S(StoneColorList color)
        //{
        //    switch (color)
        //    {
        //        case None:
        //            return "ー";
        //        case White:
        //            return "○";
        //        case Black:
        //            return "＊";
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        }
    }
}
