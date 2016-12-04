using System;
using System.Collections.Generic;
using System.Linq;
using MilkCha.Util;
using Prism.Mvvm;
using static MilkCha.Util.PlayerList;
using static MilkCha.Util.Util;

namespace MilkCha.Model
{
    public class GameBoard : BindableBase
    {
        private PlayerList[][] _board =
        {
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None}
        };

        public PlayerList[][] Board
        {
            get { return _board; }
            set { SetProperty(ref _board, value); }
        }

        public int CountWhiteColor => Board.Select(lists => lists.Count(stone => stone == Cpu)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor => Board.Select(lists => lists.Count(list => list == Player)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor => Board.Select(lists => lists.Count(list => list == None)).Aggregate((i, i1) => i + i1);

        private PlayerList GetColor(int x, int y) => IsRange(x, y) ? Board[x][y] : None;

        public void Init()
        {
            new[] { None, None, None, None, None, None, None, None }
                .CopyTo(Board[0], 0);
            new[] { None, None, None, None, None, None, None, None }
                .CopyTo(Board[1], 0);
            new[] { None, None, None, None, None, None, None, None }
                .CopyTo(Board[2], 0);
            new[] { None, None, None, Player, Cpu, None, None, None }
                .CopyTo(Board[3], 0);
            new[] { None, None, None, Cpu, Player, None, None, None }
                .CopyTo(Board[4], 0);
            new[] { None, None, None, None, None, None, None, None }
                .CopyTo(Board[5], 0);
            new[] { None, None, None, None, None, None, None, None }
                .CopyTo(Board[6], 0);
            new[] { None, None, None, None, None, None, None, None }
                .CopyTo(Board[7], 0);
        }

        public void SetColor(int x, int y, PlayerList player) => Board[x][y] = player;

        public bool IsAlreadlySet(int x, int y) => GetColor(x, y) != None;

        private bool IsReversiDirection(int x, int y, int dx, int dy, PlayerList player)
        {
            var nowColor = player;
            var nx = x + dx;
            var ny = y + dy;
            if (!IsRange(nx, ny)) return false;
            if (GetColor(nx, ny) != EnemyColor(nowColor)) return false;
            while (true)
            {
                nx += dx;
                ny += dy;
                if (!IsRange(nx, ny)) return false;
                if (GetColor(nx, ny) == None) return false;
                if (GetColor(nx, ny) == nowColor) return true;
            }
        }

        public bool IsReversiAllDirection(int x, int y, PlayerList player)
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

        private void ReversiDirection(int x, int y, int dx, int dy, PlayerList player)
        {
            if (!IsReversiDirection(x, y, dx, dy, player)) return;
            var nx = x + dx;
            var ny = y + dy;
            while (true)
            {
                if (GetColor(nx, ny) != EnemyColor(player)) break;
                if (!IsRange(nx, ny)) return;
                SetColor(nx, ny, player);
                nx += dx;
                ny += dy;
            }
        }

        public void ReversiAllDirection(int x, int y, PlayerList player)
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

        public List<Tuple<int, int>> GetEnableColorPointList(PlayerList player)
        {
            var colorPointList = new List<Tuple<int, int>>();
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (!IsAlreadlySet(i, j))
                    {
                        if (IsReversiAllDirection(i, j, player))
                        {
                            colorPointList.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }
            }
            return colorPointList;
        }
    }
}
