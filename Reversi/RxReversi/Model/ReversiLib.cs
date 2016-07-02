using System;
using RxReversi.classes;

namespace RxReversi.Model
{
    public class ReversiLib
    {
        public ReversiLib()
        {
            Board.Init();
        }

        public ReversiBoard Board { get; set; } = new ReversiBoard();
        

        public bool IsContinue()
        {
            if (Board.CountWhiteColor() == 0) return false;
            if (Board.CountBlackColor() == 0) return false;
            if (Board.CountNoneColor() == 0) return false;
            return true;
        }

        
    }
}