using System.Linq;
using System.Xml.Linq;
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

    public class ReversiLib
    {
        public ReversiBoard ReversiBoard { get; } = new ReversiBoard();
        private int WhiteStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone == White);
        private int BlackStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone == Black);
        private int NoneStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone == None);

        private StoneColorList GetEnemyColor(Stone stone)
            => stone.StoneColor == Black ? White : Black;

        public bool IsContinue() => BlackStone != 0 && WhiteStone != 0;
        private bool MatchBoard(int x, int y)
        {
            if (x > 0 || y > 0) return false;
            if (x < ReversiBoard.Board.Count() || x < ReversiBoard.Board[0].Count()) return false;
            return true;
        }

        public StoneColorList GetStoneColor(int x, int y)
            => MatchBoard(x, y) ? None : ReversiBoard.Board[x][y];

        private Stone GetStone(int x, int y)
            => new Stone { X = x, Y = y, StoneColor = GetStoneColor(x, y) };

        public bool SetStone(Stone stone)
        {
            DirectSet(stone);
            //左の石をチェック
            DirectSet(GetStone(stone.X - 1, stone.Y));
            //右の石をチェック
            DirectSet(GetStone(stone.X + 1, stone.Y));
            //上の石をチェック
            DirectSet(GetStone(stone.X, stone.Y - 1));
            //下の石をチェック
            DirectSet(GetStone(stone.X, stone.Y + 1));

            return true;
        }

        public bool DirectSet(Stone stone)
        {
            if (MatchBoard(stone.X, stone.Y)) return false;
            if (!IsChangeStoneColor(stone)) return false;
            ReversiBoard.Board[stone.X][stone.Y] = stone.StoneColor;
            return true;
        }

        private bool IsChangeStoneColor(Stone stone)
        {
            if (stone.StoneColor == None) return false;
            var enemyColor = GetEnemyColor(stone);

            var topColor = GetStoneColor(stone.X - 1, stone.Y);
            var underColor = GetStoneColor(stone.X + 1, stone.Y);
            if (enemyColor == topColor && enemyColor == underColor) return true;

            var rightcolor = GetStoneColor(stone.X, stone.Y - 1);
            var leftcolor = GetStoneColor(stone.X, stone.Y + 1);
            if (enemyColor == rightcolor && enemyColor == leftcolor) return true;

            return false;
        }
    }
}