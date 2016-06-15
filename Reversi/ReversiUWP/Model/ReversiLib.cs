using ReversiUWP.classes;
using System;
using static ReversiUWP.classes.Color;

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

        public class OverrideStoneException : Exception { }

        public void SetStone(int x, int y)
        {
            if (!Util.IsRange(x, y)) throw new IndexOutOfRangeException();
            if (Board.IsAlreadlySet(x, y, Player.NowColor)) throw new OverrideStoneException();
            
            var NowColor = Player.NowColor;
            Board.SetColor(x, y, NowColor);
        }

        public bool IsContinue()
        {
            if (Board.CountWhiteColor() == 0) return false;
            if (Board.CountBlackColor() == 0) return false;
            if (Board.CountNoneColor() == 0) return false;
            return true;
        }
    }
}
