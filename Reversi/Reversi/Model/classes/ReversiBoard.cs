using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi.Model.classes
{
    public class ReversiBoard
    {
        public Player[][] Board { get; } = {
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None},
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None},
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None},
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None},
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None},
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None},
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None},
            new[]
                {Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None}
        };

        public void Init()
        {
            new[]
                {
                    Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[0], 0);
            new[]
                {
                    Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[1], 0);
            new[]
                {
                    Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[2], 0);
            new[]
                {
                    Player.None, Player.None, Player.None, Player.Black, Player.White, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[3], 0);
            new[]
                {
                    Player.None, Player.None, Player.None, Player.White, Player.Black, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[4], 0);
            new[]
                {
                    Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[5], 0);
            new[]
                {
                    Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[6], 0);
            new[]
                {
                    Player.None, Player.None, Player.None, Player.None, Player.None, Player.None, Player.None,
                    Player.None
                }
                .CopyTo(Board[7], 0);
        }

        public int CountWhiteColor()
            => Board.Select(lists => lists.Count(stone => stone == Player.White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => Board.Select(lists => lists.Count(list => list == Player.Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => Board.Select(lists => lists.Count(list => list == Player.None)).Aggregate((i, i1) => i + i1);

        private Player GetColor(int x, int y) => Util.IsRange(x, y) ? Board[x][y] : Player.None;

        public void SetColor(int x, int y, Player player)
        {
            Board[x][y] = player;
        }

        public bool IsAlreadlySet(int x, int y)
            => GetColor(x, y) != Player.None;

        private bool IsReversiDirection(int x, int y, int dx, int dy, Player player)
        {
            var nowColor = player;
            var nx = x + dx;
            var ny = y + dy;
            if (!Util.IsRange(nx, ny)) return false;
            if (GetColor(nx, ny) != Util.EnemyColor(nowColor)) return false;
            while (true)
            {
                nx += dx;
                ny += dy;
                if (!Util.IsRange(nx, ny)) return false;
                if (GetColor(nx, ny) == Player.None) return false;
                if (GetColor(nx, ny) == nowColor) return true;
            }
        }

        public bool IsReversiAllDirection(int x, int y, Player player)
        {
            if (IsReversiDirection(x, y, -1, 0, player)) return true; // Up
            if (IsReversiDirection(x, y, -1, 1, player)) return true; // Upper Right
            if (IsReversiDirection(x, y, 0, 1, player)) return true; // Right
            if (IsReversiDirection(x, y, 1, 1, player)) return true; // Lower Right
            if (IsReversiDirection(x, y, 1, 0, player)) return true; // Low
            if (IsReversiDirection(x, y, 1, -1, player)) return true; // Lower Left
            if (IsReversiDirection(x, y, 0, -1, player)) return true; // Left
            if (IsReversiDirection(x, y, -1, -1, player)) return true; // Upper Left

            return false;
        }

        private void ReversiDirection(int x, int y, int dx, int dy, Player player)
        {
            if (!IsReversiDirection(x, y, dx, dy, player)) return;
            var nx = x + dx;
            var ny = y + dy;
            while (true)
            {
                if (GetColor(nx, ny) != Util.EnemyColor(player)) break;
                if (!Util.IsRange(nx, ny)) return;
                SetColor(nx, ny, player);
                nx += dx;
                ny += dy;
            }
        }

        public void ReversiAllDirection(int x, int y, Player player)
        {
            ReversiDirection(x, y, -1, 0, player); // Up
            ReversiDirection(x, y, -1, 1, player); // Upper Right
            ReversiDirection(x, y, 0, 1, player); // Right
            ReversiDirection(x, y, 1, 1, player); // Lower Right
            ReversiDirection(x, y, 1, 0, player); // Low
            ReversiDirection(x, y, 1, -1, player); // Lower Left
            ReversiDirection(x, y, 0, -1, player); // Left
            ReversiDirection(x, y, -1, -1, player); // Upper Left
        }

        public List<Tuple<int,int>> GetEnableColorPointList(Player player)
        {
            var colorPointList = new List<Tuple<int, int>>();
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    if (IsEnableColor(new Tuple<int, int>(i,j), player))
                            colorPointList.Add(new Tuple<int,int>(i, j));
            return colorPointList;
        }

        private bool IsEnableColor(Tuple<int, int> tuple,Player player) 
            => !IsAlreadlySet(tuple.Item1, tuple.Item2) && IsReversiAllDirection(tuple.Item1, tuple.Item2, player);
    }
}