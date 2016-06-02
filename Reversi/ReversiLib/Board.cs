using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReversiLib.Color;

namespace ReversiLib
{
    public class Board
    {
        public Board()
        {
            Init();
        }

        public Color[][] board { get; set; } = {
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None},
            new[] {None, None, None, None, None, None, None, None}
        };

        public int Length => board.Length;

        public int CountWhiteColor()
            => board.Select(lists => lists.Count(stone => stone == White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => board.Select(lists => lists.Count(list => list == Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => board.Select(lists => lists.Count(list => list == None)).Aggregate((i, i1) => i + i1);

        public Color GetColor(int x, int y)
            => board[y][x];

        public void SetColor(int x, int y, Color color)
            => board[y][x] = color;

        public bool IsRange(int x, int y)
        {
            if (x < 0 || y < 0) return false;
            if (board.Length < y) return false;
            if (board[0].Length < x) return false;
            return true;
        }

        public void Init()
        {
            new[] { None, None, None, None, None, None, None, None }.CopyTo(board[0], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(board[1], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(board[2], 0);
            new[] { None, None, None, Black, White, None, None, None }.CopyTo(board[3], 0);
            new[] { None, None, None, White, Black, None, None, None }.CopyTo(board[4], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(board[5], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(board[6], 0);
            new[] { None, None, None, None, None, None, None, None }.CopyTo(board[7], 0);
        }
    }
}
