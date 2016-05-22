using System;
using System.Linq;
using static ReversiLib.Color;

namespace ReversiLib
{
    public enum Color
    {
        Black,
        White,
        None
    };

    public class Player
    {
        public Color TurnColor;
        public void Change() => TurnColor = Reversi.EnemyColor(TurnColor);
        public Color NowColor => TurnColor;
    }

    public class OverlapStone : Exception { }
    public class NotEnableSetStone : Exception { }

    public class Reversi
    {
        public Color[][] Board { get; set; } = {
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None}
        };

        public int CountWhiteColor()
            => Board.Select(lists => lists.Count(stone => stone == White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => Board.Select(lists => lists.Count(list => list == Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => Board.Select(lists => lists.Count(list => list == None)).Aggregate((i, i1) => i + i1);

        //値がボードの範囲内か調べる
        public bool IsRangeOfBoard(int x, int y)
        {
            if (x < 0 || x > Board.Length - 1) return false;
            if (y < 0 || y > Board[0].Length - 1) return false;

            return true;
        }

        public static Color EnemyColor(Color color)
        {
            switch (color)
            {
                case Black:
                    return White;
                case White:
                    return Black;
                case None:
                    return None;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        public Color GetColor(int x, int y) => IsRangeOfBoard(x, y) ? Board[x][y] : None;

        public void Init()
        {
            new[] { None, None, None, None, None, None, None, None }.CopyTo(Board[0], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(Board[1], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(Board[2], 0);
            new[] { None, None, None, Black, White, None, None, None }.CopyTo(Board[3], 0);
            new[] { None, None, None, White, Black, None, None, None }.CopyTo(Board[4], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(Board[5], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(Board[6], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(Board[7], 0);
        }

        //一方向にひっくり返せる石があるか確認
        private bool IsReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            var nx = x + dx;
            var ny = y + dy;
            if (GetColor(nx, ny) == color) return false;
            while (true)
            {
                if (GetColor(nx, ny) == None) return false;
                if (GetColor(nx, ny) == color) break;
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
            if(!IsReversiDirection(x,y,dx,dy,color)) return;
            var nx = x + dx;
            var ny = y + dy;
            if (GetColor(nx, ny) != EnemyColor(color)) return;
            while (true)
            {
                if (GetColor(nx, ny) != EnemyColor(color)) break;
                Board[nx][ny] = color;
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
        {
            if (GetColor(x, y) == None) return false;

            return true;
        }
        
        //Set Color on Board
        public bool SetColor(int x, int y, Color color)
        {
            if (!IsRangeOfBoard(x, y)) return false;
            if (Board[x][y] != None)
            {
                throw new OverlapStone();
            }
            if (!IsReversiAllDirection(x, y, color))
            {
                throw new NotEnableSetStone();
            }
            Board[x][y] = color;
            ReversiAllDirection(x, y, color);
            return true;
        }

        public bool IsContinue()
        {
            if (CountBlackColor() == 0) return false;
            if (CountWhiteColor() == 0) return false;
            if (CountNoneColor() == 0) return false;
            return true;
        }
    }
}
