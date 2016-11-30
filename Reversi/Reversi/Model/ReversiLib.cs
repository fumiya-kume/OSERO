using System;
using Reversi.Model.classes;

namespace Reversi.Model
{
    public class ReversiLib
    {
        public ReversiLib()
        {
            Board.Init();
        }

        public ReversiBoard Board { get; set; } = new ReversiBoard();

        public void SetStone(int x, int y, classes.Player player)
        {
            if (Board.IsAlreadlySet(x, y)) throw new OverrideStoneException("すでに石が置かれています");
            if (!Board.IsReversiAllDirection(x, y, player)) throw new DisableStone("その場所に駒を置くことはできません");
            var nowColor = player;
            Board.SetColor(x, y, nowColor);
            Board.ReversiAllDirection(x, y, player);
        }

        public bool IsContinue(classes.Player player)
        {
            if (Board.CountWhiteColor() == 0) return false;
            if (Board.CountBlackColor() == 0) return false;
            if (Board.CountNoneColor() == 0) return false;
            if (Board.GetEnableColorPointList(player).Count == 0) return false;
            return true;
        }

        public class DisableStone : Exception
        {
            public DisableStone(string message) : base(message)
            {
            }
        }

        public class OverrideStoneException : Exception
        {
            public OverrideStoneException(string message) : base(message)
            {
            }
        }
    }
}