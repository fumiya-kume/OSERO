using System;
using ReversiUWP.classes;

namespace ReversiUWP.Model
{
    public class ReversiLib
    {
        public ReversiLib()
        {
            Board.Init();
        }

        public ReversiBoard Board { get; set; } = new ReversiBoard();
        public Player Player { get; set; } = new Player();

        public void SetStone(int x, int y)
        {
            if (!Util.IsRange(x, y)) throw new IndexOutOfRangeException();
            if (Board.IsAlreadlySet(x, y)) throw new OverrideStoneException();

            var nowColor = Player.NowColor;
            Board.SetColor(x, y, nowColor);
            Board.ReversiAllDirection(x, y, Player.NowColor);
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