using System.Linq;

namespace ReversiLib
{
    public class ReversiBoard
    {
        private Reversi _reversi;

        public ReversiBoard(Reversi reversi)
        {
            _reversi = reversi;
        }

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

        public int CountWhiteColor()
            => Board.Select(lists => lists.Count(stone => stone == Color.White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => Board.Select(lists => lists.Count(list => list == Color.Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => Board.Select(lists => lists.Count(list => list == Color.None)).Aggregate((i, i1) => i + i1);

        public Color GetColor(int x, int y) => _reversi.Util.IsRange(x, y) ? Board[x][y] : Color.None;

        public void Init()
        {
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(Board[0], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(Board[1], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(Board[2], 0);
            new[] { Color.None, Color.None, Color.None, Color.Black, Color.White, Color.None, Color.None, Color.None }.CopyTo(Board[3], 0);
            new[] { Color.None, Color.None, Color.None, Color.White, Color.Black, Color.None, Color.None, Color.None }.CopyTo(Board[4], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(Board[5], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(Board[6], 0);
            new[] { Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None, Color.None }.CopyTo(Board[7], 0);
        }

        public bool SetColor(int x, int y, Color color)
        {
            if (!_reversi.Util.IsRange(x, y)) return false;
            if (Board[x][y] != Color.None)
            {
                throw new OverlapStone();
            }
            if (!_reversi.IntelligenceService.IsReversiAllDirection(x, y))
            {
                throw new NotEnableSetStone();
            }
            Board[x][y] = color;
            _reversi.IntelligenceService.ReversiAllDirection(x, y, color);
            return true;
        }
    }
}