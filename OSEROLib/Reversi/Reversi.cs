using System.Linq;
using static Reversi.StoneColorList;

namespace Reversi
{
    public enum StoneColorList { None, White, Black }
    public class Stone
    {
        public StoneColorList StoneColor { get; set; } = None;
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ReversiBoard
    {
        public StoneColorList[][] Board { get; set; } = {
                new[] {None, None, None, None, None, None, None, None},new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},new[] {None, None, None, None, None, None, None, None},
                new[] {None, None, None, None, None, None, None, None},new[] {None, None, None, None, None, None, None, None}
            };
    }
    public class Reversi
    {
        public ReversiBoard Board { get; set; } = new ReversiBoard();

        public int WhiteStone() => Board.Board.SelectMany(stone => stone).Count(stone => stone == White);
        public int BlackStone() => Board.Board.SelectMany(stone => stone).Count(stone => stone == Black);

    }
}
