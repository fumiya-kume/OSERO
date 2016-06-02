using System;
using static ReversiLib.Color;

namespace ReversiLib
{
    

    public class OverlapStone : Exception { }
    public class NotEnableSetStone : Exception { }

    public class Reversi
    {
        public Board board { get; set; } = new Board();

        //一方向にひっくり返せる石があるか確認
        private bool IsReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            var nx = x + dx;
            var ny = y + dy;
            if (board.GetColor(x,y) == color) return false;
            while (true)
            {
                if (board.GetColor(x, y) == None) return false;
                if (board.GetColor(x, y) == color) break;
                nx += dx;
                ny += dy;
            }
            return true;
        }

        // Can Reversi Color on vicinty
        private bool IsReversiAllDirection(int x, int y, Color color)
        {
            if (IsReversiDirection(x, y, -1, 0, color)) return true; // Up
            if (IsReversiDirection(x, y, -1, 1, color)) return true; // Upper Right
            if (IsReversiDirection(x, y, 0, 1, color)) return true;  // Right
            if (IsReversiDirection(x, y, 1, 1, color)) return true; // Lower Right
            if (IsReversiDirection(x, y, 1, 0, color)) return true; // Low
            if (IsReversiDirection(x, y, 1, -1, color)) return true; // Lower Left
            if (IsReversiDirection(x, y, 0, -1, color)) return true; // Left
            if (IsReversiDirection(x, y, -1, -1, color)) return true; // Upper Left

            return false;
        }

        private void ReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            if (!IsReversiDirection(x, y, dx, dy, color)) return;
            var nx = x + dx;
            var ny = y + dy;
            if (board.GetColor(x, y) != Util.EnemyColor(color)) return;
            while (true)
            {
                if (board.GetColor(x,y) != Util.EnemyColor(color)) break;
                board.SetColor(x,y,color);
                nx += dx;
                ny += dy;
            }
        }

        private void ReversiAllDirection(int x, int y, Color color)
        {
            ReversiDirection(x, y, -1, 0, color); // Up
            ReversiDirection(x, y, -1, 1, color); // Upper Right
            ReversiDirection(x, y, 0, 1, color);   // Right
            ReversiDirection(x, y, 1, 1, color); // Lower Right
            ReversiDirection(x, y, 1, 0, color); // Low
            ReversiDirection(x, y, 1, -1, color);// Lower Left
            ReversiDirection(x, y, 0, -1, color); // Left
            ReversiDirection(x, y, -1, -1, color); // Upper Left
        }

        public bool IsAlreadSetColor(int x, int y) 
            => board.GetColor(x,y) != None;

        public bool CanSetStone(int x, int y, Color color)
        {
            if (!board.IsRange(x, y)) return false;
            if (board.GetColor(x,y) != None) return false;
            if (!IsReversiAllDirection(x, y, color)) return false;
            return true;
        }

        public bool IsSkip()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.board[0].Length; j++)
                {
                    if (CanSetStone(i, j, board.GetColor(i,j)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        public void SetColor(int y, int x, Color color)
        {
            if (!board.IsRange(y, x)) throw new IndexOutOfRangeException();
            if (board.GetColor(x,y) != None) throw new OverlapStone();
            if (!IsReversiAllDirection(y, x, color)) throw new NotEnableSetStone();
            board.SetColor(x,y,color);
            ReversiAllDirection(y, x, color);
        }

        public bool IsContinue()
        {
            if (board.CountBlackColor() == 0) return false;
            if (board.CountWhiteColor() == 0) return false;
            if (board.CountNoneColor() == 0) return false;
            return true;
        }

        public Color[][] GetAllBoardData()
        {
            return board.board;
        }
    }
}
