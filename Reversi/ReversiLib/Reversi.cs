using System;
using System.Linq;
using static ReversiLib.Color;

namespace ReversiLib
{


    public class Reversi
    {
        public ReversiBoard Board { get; }=new ReversiBoard();

        public intelligenceService IntelligenceService { get; } = new intelligenceService();
        
        public bool SetColor(int x, int y, Color color)
        {
            if (Util.IsRange(x, y)) return false;
            if (Board.IsNone(x,y))
            {
                throw new OverlapStone();
            }
            if (!_reversi.IsReversiAllDirection(x, y))
            {
                throw new NotEnableSetStone();
            }
            Board[x][y] = color;
            _reversi.ReversiAllDirection(x, y, color);
            return true;
        }

        public bool IsAlreadSetColor(int x, int y)
        {
            if (Board.GetColor(x, y) == None) return false;

            return true;
        }

        public bool CanSetStone(int x, int y, Color color)
        {
            if (!Util.IsRange(x, y)) return false;
            if (Board.Board[x][y] != None) return false;
            if (!IntelligenceService.IsReversiAllDirection(x, y)) return false;
            return true;
        }

        public bool IsSkip()
        {
            for (int i = 0; i < Board.Board.Length; i++)
            {
                for (int j = 0; j < Board.Board[0].Length; j++)
                {
                    if (IntelligenceService.IsReversiAllDirection(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Set Color on Board

        public bool IsContinue()
        {
            if (Board.CountBlackColor() == 0) return false;
            if (Board.CountWhiteColor() == 0) return false;
            if (Board.CountNoneColor() == 0) return false;
            return true;
        }
    }
}
