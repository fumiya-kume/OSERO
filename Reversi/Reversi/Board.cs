using System.Linq;
using ReversiLib;

namespace Reversi
{
    public class Board
    {
        public Board()
        {
            Init();
        }

        public Color[][] board { get; set; } = {
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None},
            new[] {Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None}
        };

        public int Length => board.Length;

        public int CountWhiteColor()
            => board.Select(lists => lists.Count(stone => stone == Color.White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => board.Select(lists => lists.Count(list => list == Color.Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => board.Select(lists => lists.Count(list => list == Color.None)).Aggregate((i, i1) => i + i1);

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
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(board[0], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(board[1], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(board[2], 0);
            new[] { Color.None, Color.None, Color.None, Color.Black, Color.White, Color.None, Color.None, Color.None }.CopyTo(board[3], 0);
            new[] { Color.None, Color.None, Color.None, Color.White, Color.Black, Color.None, Color.None, Color.None }.CopyTo(board[4], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(board[5], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(board[6], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(board[7], 0);
        }

        public bool IsNone(int x, int y)
            => GetColor(x, y) == Color.None;
    }
}
