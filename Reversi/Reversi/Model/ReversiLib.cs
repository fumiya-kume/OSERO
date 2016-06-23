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

        public class DisableStone : Exception
        {
            public DisableStone(string message) : base(message)
            {
            }
        }

        public void SetStone(int x, int y,　Color color)
        {
            if (!Util.IsRange(x, y)) throw new IndexOutOfRangeException("値がおかしいです");
            if (Board.IsAlreadlySet(x, y)) throw new OverrideStoneException("すでに石が置かれています");
            if(!Board.IsReversiAllDirection(x,y)) throw new DisableStone("その場所に駒を置くことはできません");
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
            public OverrideStoneException(string message) : base(message)
            {
            }
        }
    }
}