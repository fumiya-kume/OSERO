using System;
using Reversi.classes;

namespace Reversi.Model
{
    public class ReversiLib
    {
        public ReversiLib()
        {
            Board.Init();
        }

        public ReversiBoard Board { get; set; } = new ReversiBoard();

        public void SetStone(int x, int y,　Color color)
        {
            if (!Util.IsRange(x, y)) throw new IndexOutOfRangeException();
            if (Board.IsAlreadlySet(x, y)) throw new OverrideStoneException();

            var nowColor = color;
            Board.SetColor(x, y, nowColor);
            Board.ReversiAllDirection(x, y, color);
        }

        public bool IsContinue()
        {
            if (Board.CountWhiteColor() == 0) return false;
            if (Board.CountBlackColor() == 0) return false;
            if (Board.CountNoneColor() == 0) return false;
            return true;
        }

        public class OverrideStoneException : Exception
        {
        }
    }
}