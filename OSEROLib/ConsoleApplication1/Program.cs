using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reversi;

namespace ConsoleApplication1
{
    class Program
    {
        public static ReversiLib reversilib { get; set; } = new ReversiLib();
        static void Main(string[] args)
        {
            Console.WriteLine("Game Start");
            dumpBoard();
        }

        public static void dumpBoard()
        {
            Console.WriteLine( 123456789);
            for (var i = 0; i < 8 ; i++)
            {
                reversilib.Board[i + 1].Select((stone, i1) =>
                {
                    Console.Write(Stone2String(stone));
                    return stone;
                });
                Console.WriteLine(" ");
            }

        }

        public static string Stone2String(Stone stone)
        {
            switch (stone.StoneColor)
            {
                case Stone.StoneColorList.None:
                    return "-";
                case Stone.StoneColorList.White:
                    return "○";
                case Stone.StoneColorList.Black:
                    return "*";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
