using System.Collections.Generic;
using System.Linq;
using Reversi.Model;
using System;

namespace Reversi.classes
{
    public class ReversiBoard
    {
        public Color[][] Board { get; set; } = {
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
        };

        public void Init()
        {
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
                .CopyTo(Board[0], 0);
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
                .CopyTo(Board[1], 0);
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
                .CopyTo(Board[2], 0);
            new[] {Color.None, Color.None, Color.None, Color.Black, Color.White, Color.None, Color.None, Color.None}
                .CopyTo(Board[3], 0);
            new[] {Color.None, Color.None, Color.None, Color.White, Color.Black, Color.None, Color.None, Color.None}
                .CopyTo(Board[4], 0);
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
                .CopyTo(Board[5], 0);
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
                .CopyTo(Board[6], 0);
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
                .CopyTo(Board[7], 0);
        }

        public int CountWhiteColor()
            => Board.Select(lists => lists.Count(stone => stone == Color.White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => Board.Select(lists => lists.Count(list => list == Color.Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => Board.Select(lists => lists.Count(list => list == Color.None)).Aggregate((i, i1) => i + i1);

        public bool IsNone(int x, int y)
            => GetColor(x, y) == Color.None;

        public bool IsEqualColor(int x, int y, Color color)
            => GetColor(x, y) == color;

        public bool IsEnemyColor(int x, int y, Color color)
            => GetColor(x, y) == Util.EnemyColor(color);

        public Color GetColor(int x, int y) => Util.IsRange(x, y) ? Board[x][y] : Color.None;

        public void SetColor(int x, int y, Color color)
        {
            Board[x][y] = color;
        }

        public bool IsAlreadlySet(int x, int y)
            => GetColor(x, y) != Color.None;

        private bool IsReversiDirection(int x, int y, int dx, int dy)
        {
            var nowColor = GetColor(x, y);
            var nx = x + dx;
            var ny = y + dy;
            if (GetColor(nx, ny) != Util.EnemyColor(nowColor)) return false;
            while (true)
            {
                if (GetColor(nx, ny) == Color.None) return false;
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
            if (IsReversiDirection(x, y, 0, 1)) return true; // Right
            if (IsReversiDirection(x, y, 1, 1)) return true; // Lower Right
            if (IsReversiDirection(x, y, 1, 0)) return true; // Low
            if (IsReversiDirection(x, y, 1, -1)) return true; // Lower Left
            if (IsReversiDirection(x, y, 0, -1)) return true; // Left
            if (IsReversiDirection(x, y, -1, -1)) return true; // Upper Left

            return false;
        }

        private bool IsReversiDirectionWithColor(int x, int y, int dx, int dy,Color color)
        {
            var nowColor = GetColor(x, y);
            var nx = x + dx;
            var ny = y + dy;
            if (GetColor(nx, ny) != Util.EnemyColor(nowColor)) return false;
            while (true)
            {
                if (GetColor(nx, ny) == Color.None) return false;
                if (GetColor(nx, ny) == nowColor) break;
                nx += dx;
                ny += dy;
            }
            return true;
        }

        public bool IsReversiAllDirectionWithColor(int x, int y,Color color)
        {
            if (IsReversiDirectionWithColor(x, y, -1, 0   ,color)) return true; // Up
            if (IsReversiDirectionWithColor(x, y, -1, 1   ,color)) return true; // Upper Right
            if (IsReversiDirectionWithColor(x, y, 0, 1   ,color) )return true; // Right
            if (IsReversiDirectionWithColor(x, y, 1, 1   ,color)) return true; // Lower Right
            if (IsReversiDirectionWithColor(x, y, 1, 0   ,color)) return true; // Low
            if (IsReversiDirectionWithColor(x, y, 1, -1   ,color)) return true; // Lower Left
            if (IsReversiDirectionWithColor(x, y, 0, -1   ,color)) return true; // Left
            if (IsReversiDirectionWithColor(x, y, -1, -1,color)) return true; // Upper Left

            return false;
        }

        private void ReversiDirection(int x, int y, int dx, int dy, Color color)
        {
            if (!IsReversiDirection(x, y, dx, dy)) return;
            var nx = x + dx;
            var ny = y + dy;
            if (GetColor(nx, ny) != Util.EnemyColor(color)) return;
            while (true)
            {
                if (GetColor(nx, ny) != Util.EnemyColor(color)) break;
                SetColor(nx, ny, color);
                nx += dx;
                ny += dy;
            }
        }

        public void ReversiAllDirection(int x, int y, Color color)
        {
            ReversiDirection(x, y, -1, 0, color); // Up
            ReversiDirection(x, y, -1, 1, color); // Upper Right
            ReversiDirection(x, y, 0, 1, color); // Right
            ReversiDirection(x, y, 1, 1, color); // Lower Right
            ReversiDirection(x, y, 1, 0, color); // Low
            ReversiDirection(x, y, 1, -1, color); // Lower Left
            ReversiDirection(x, y, 0, -1, color); // Left
            ReversiDirection(x, y, -1, -1, color); // Upper Left
        }

        public List<ColorPoint> GetEnableColorPointList(Color color)
        {
            var ColorPointList = new List<ColorPoint>();
            for (var i = 0; i < 7; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    if (!IsAlreadlySet(i, j))
                    {
                        var ifBoard = (ReversiBoard)MemberwiseClone();
                        if (ifBoard.IsReversiAllDirectionWithColor(i, j,color))
                        {
                            ColorPointList.Add(new ColorPoint {x = i, y = j});
                        }
                    }
                }
            }
            return ColorPointList;
        }
    }
}