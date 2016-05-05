using System.Linq;
using static Reversi.Stone;

namespace Reversi
{

    public class Stone
    {
        public enum StoneColorList { None, White, Black }
        public StoneColorList StoneColor { get; set; } = StoneColorList.None;
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ReversiBoard
    {
        public Stone[][] Board { get; set; } = {
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()}
            };
    }

    public class ReversiLib
    {
        public ReversiBoard ReversiBoard { get; } = new ReversiBoard();

        private int WhiteStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone.StoneColor == StoneColorList.White);
        private int BlackStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone.StoneColor == StoneColorList.Black);
        private int NoneStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone.StoneColor == StoneColorList.None);
        
        private Stone GetTopStone(Stone stone) => ReversiBoard.Board[stone.X - 1][stone.Y];
        private Stone GetUnderStone(Stone stone) => ReversiBoard.Board[stone.X + 1][stone.Y];
        private Stone GetRightStone(Stone stone) => ReversiBoard.Board[stone.X][stone.Y - 1];
        private Stone GetLeftStone(Stone stone) => ReversiBoard.Board[stone.X][stone.Y + 1];
        private StoneColorList GetEnemyColor(Stone stone) => stone.StoneColor == StoneColorList.Black ? StoneColorList.White : StoneColorList.Black;

        public bool IsContinue() => BlackStone != 0 && WhiteStone != 0 && NoneStone != 0;
        private bool MatchBoard(int x, int y) => x <= 0 && x >= ReversiBoard.Board.Count() && y <= 0 && y >= ReversiBoard.Board[0].Length;
        private bool IsNone(Stone stone) => stone.StoneColor == StoneColorList.None;

        public Stone GetStone(int x, int y) => ReversiBoard.Board[x][y];
        public bool SetStone(Stone stone)
        {
            if (MatchBoard(stone.X, stone.Y)) return false;
            if (!IsNone(ReversiBoard.Board[stone.X][stone.Y])) return false;
            if (!IsChangeStoneColor(stone)) return false;

            ReversiBoard.Board[stone.X][stone.Y] = stone;
            return true;
        }

        private bool IsChangeStoneColor(Stone stone)
        {
            if (stone.StoneColor == StoneColorList.None) return false;

            if (GetEnemyColor(stone) == GetTopStone(stone).StoneColor &&
                GetEnemyColor(stone) == GetUnderStone(stone).StoneColor) return true;

            if (GetEnemyColor(stone) == GetRightStone(stone).StoneColor &&
                GetEnemyColor(stone) == GetLeftStone(stone).StoneColor) return true;
            return false;
        }
    }
}