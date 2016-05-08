using System;
using System.Linq;
using System.Xml.Linq;
using static ReversiLib.ColorList;

namespace ReversiLib
{
    public enum ColorList
    {
        Black,
        White,
        None
    };


    public class Reversi
    {
        public ColorList[][] Board { get; set; } = {
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

        public bool IsRangeOfBoard(int x, int y)
        {
            if (x < 0 || x > Board.Length - 1) return false;
            if (y < 0 || y > Board[0].Length - 1) return false;

            return true;
        }

        public void SetColor(int x, int y, ColorList color)
        {
            if (!IsRangeOfBoard(x, y)) throw new IndexOutOfRangeException($"x:{x} y:{y}");
            Board[x][y] = color;
        }

        public ColorList EnemyColor(ColorList color)
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

        public bool IsChangeColor(int x, int y)
        {
            if (!IsRangeOfBoard(x, y)) throw new IndexOutOfRangeException($"x:{x} y:{y}");
            var BaseColor = Board[x][y];

            var topColor = IsRangeOfBoard(x - 1, y) ? Board[x - 1][y] : None;
            var underColor = IsRangeOfBoard(x + 1, y) ? Board[x - 1][y] : None;

            if (topColor == None || underColor == None ||
                topColor == underColor && topColor == EnemyColor(BaseColor)) return true;

            var rightColor = IsRangeOfBoard(x, y - 1) ? Board[x][y - 1] : None;
            var leftColor = IsRangeOfBoard(x, y + 1) ? Board[x][y + 1] : None;

            if (rightColor == None || leftColor == None ||
                rightColor == underColor && rightColor == EnemyColor(BaseColor)) return true;

            return false;
        }
    }
}
