using System.Linq;
using static ReversiLib.Color;

namespace ReversiLib
{
    public class ReversiBoard
    {
        public ReversiBoard()
        {
        }

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

        public int CountWhiteColor()
            => Board.Select(lists => lists.Count(stone => stone == White)).Aggregate((i, i1) => i + i1);

        public int CountBlackColor()
            => Board.Select(lists => lists.Count(list => list == Black)).Aggregate((i, i1) => i + i1);

        public int CountNoneColor()
            => Board.Select(lists => lists.Count(list => list == None)).Aggregate((i, i1) => i + i1);

        public Color GetColor(int x, int y) => Util.IsRange(x, y) ? Board[x][y] : None;

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

        public bool SetColor(int x, int y, Color color)
        {
            if (!Util.IsRange(x, y)) return false;
            if (Board[x][y] != None)
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