using System;
using static ReversiLib.Color;

namespace ReversiLib
{


    public class OverlapStone : Exception { }
    public class NotEnableSetStone : Exception { }

    public class Reversi
    {
        public Board board { get; set; } = new Board();

        private bool Check(int x, int y, Color color)
            => board.GetColor(x, y) == color;

        private bool IsEnemyColor(int x, int y, Color color)
            => board.GetColor(x, y) == Util.EnemyColor(color);

        //一方向にひっくり返せる石があるか確認
        private bool IsReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            var nx = x + dx;
            var ny = y + dy;
            if (!IsEnemyColor(x, y, color)) return false;
            while (true)
            {
                if (board.IsNone(x, y)) return false;
                if (Check(x, y, color)) break;
                nx += dx;
                ny += dy;
            }
            return true;
        }

        // Can Reversi Color on vicinty
        private bool IsReversiAllDirection(int x, int y, Color color)
        {
            if (IsReversiDirection(x, y, 0, 1, color)) return true;
            if (IsReversiDirection(x, y, 0, -1, color)) return true;
            if (IsReversiDirection(x, y, 1, 0, color)) return true;
            if (IsReversiDirection(x, y, 1, 1, color)) return true;
            if (IsReversiDirection(x, y, 1, -1, color)) return true;
            if (IsReversiDirection(x, y, -1, 0, color)) return true;
            if (IsReversiDirection(x, y, -1, 1, color)) return true;
            if (IsReversiDirection(x, y, -1, -1, color)) return true;

            return false;
        }

        private void ReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            var nx = x + dx;
            var ny = y + dy;
            if (!IsEnemyColor(x, y, color)) return;
            while (true)
            {
                if (board.IsNone(x, y)) return;
                if (Check(x, y, color)) break;
                board.SetColor(x, y, color);
                nx += dx;
                ny += dy;
            }
        }

        private void ReversiAllDirection(int x, int y, Color color)
        {
            ReversiDirection(x, y, 0, 1, color);
            ReversiDirection(x, y, 0, -1, color);
            ReversiDirection(x, y, 1, 0, color);
            ReversiDirection(x, y, 1, -1, color);
            ReversiDirection(x, y, 1, 1, color);
            ReversiDirection(x, y, -1, 0, color);
            ReversiDirection(x, y, -1, -1, color);
            ReversiDirection(x, y, -1, -1, color);
        }

        public bool IsAlreadSetColor(int x, int y)
            => board.GetColor(x, y) != None;

        public bool CanSetStone(int x, int y, Color color)
        {
            if (!board.IsRange(x, y)) return false;
            if (board.GetColor(x, y) != None) return false;
            if (!IsReversiAllDirection(x, y, color)) return false;
            return true;
        }

        public bool IsSkip()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (CanSetStone(i, j, board.GetColor(i, j)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetColor(int x, int y, Color color)
        {
            if (!board.IsRange(x, y)) throw new IndexOutOfRangeException();
            if (board.GetColor(x, y) != None) throw new OverlapStone();
            if (!IsReversiAllDirection(x, y, color)) throw new NotEnableSetStone();
            board.SetColor(x, y, color);
            ReversiAllDirection(x, y, color);
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

        public Color IsWinnerColor()
        {
            if (board.CountWhiteColor() < board.CountBlackColor())
            {
                return Black;
            }
            else if (board.CountWhiteColor() > board.CountBlackColor())
            {
                return White;
            }
            else
            {
                return None;
            }
        }
    }
}
