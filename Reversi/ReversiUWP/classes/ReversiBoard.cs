using System.Linq;
using static ReversiUWP.classes.Color;
using static ReversiUWP.Model.Util;

namespace ReversiUWP.classes
{
    public class ReversiBoard
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

        public int CountWhiteColor()
            => Board.Select(lists => lists.Count(stone => stone == White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => Board.Select(lists => lists.Count(list => list == Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => Board.Select(lists => lists.Count(list => list == None)).Aggregate((i, i1) => i + i1);

        public bool IsNone(int x, int y)
            => GetColor(x, y) == None;

        public bool IsEqualColor(int x, int y, Color color)
            => GetColor(x, y) == color;

        public bool IsEnemyColor(int x, int y, Color color)
            =>GetColor(x,y) == EnemyColor(color);

        public Color GetColor(int x, int y) => IsRange(x, y) ? Board[x][y] : None;

        public void SetColor(int x, int y, Color color)
        {
            Board[y][x] = color;
        }

        public bool IsAlreadlySet(int x, int y, Color color)
        => GetColor(x, y) != None;

        private bool IsReversiDirection(int x, int y, int dx, int dy)
        {
            var nowColor = GetColor(x, y);
            var nx = x + dx;
            var ny = y + dy;
            if (GetColor(nx, ny) != EnemyColor(nowColor)) return false;
            while (true)
            {
                if (GetColor(nx, ny) == None) return false;
                if (GetColor(nx, ny) == nowColor) break;
                nx += dx;
                ny += dy;
            }
            return true;
        }

        public bool IsReversiAllDirection(int x, int y)
        {
            if (IsReversiDirection(x, y, -1, 0)) return true; // Up
            if (IsReversiDirection(x, y, -1, 1)) return true; // Upper Right
            if (IsReversiDirection(x, y, 0, 1)) return true;  // Right
            if (IsReversiDirection(x, y, 1, 1)) return true; // Lower Right
            if (IsReversiDirection(x, y, 1, 0)) return true; // Low
            if (IsReversiDirection(x, y, 1, -1)) return true; // Lower Left
            if (IsReversiDirection(x, y, 0, -1)) return true; // Left
            if (IsReversiDirection(x, y, -1, -1)) return true; // Upper Left

            return false;
        }

        private void ReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            if (!IsReversiDirection(x, y, dx, dy)) return;
            var nx = x + dx;
            var ny = y + dy;
            if (GetColor(nx, ny) != EnemyColor(color)) return;
            while (true)
            {
                if (GetColor(nx, ny) != EnemyColor(color)) break;
                SetColor(nx, ny, color);
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
    }
}