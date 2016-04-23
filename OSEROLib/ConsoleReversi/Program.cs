using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReversi
{
    class Program
    {
        public ReversiLib reversilib { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Console Reversi is OK\r\n");
            Console.WriteLine("*********************\r\n");
            Console.WriteLine("Reversi Board\r\n");
            Console.Write("  123456789");


        }

        private void DumpBoard()
        {
            for (var i = 0; i < 9; i++)
            {
                Console.Write("\r\n" + i + " ");
                for (var j = 0; j < 9; j++)
                {
                    //Console.Write(PutStoneString());
                }
            }
        }

        public static string PutStoneString(StoneInfo.StoneColorList colorList)
        {
            switch (colorList)
            {
                case StoneInfo.StoneColorList.None:
                    return " ";
                case StoneInfo.StoneColorList.White:
                    return "○";
                case StoneInfo.StoneColorList.Black:
                    return "*";
            }
            return "";
        }
    }
}
