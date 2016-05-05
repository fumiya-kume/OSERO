using System.Linq;

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

        public int WhiteStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone.StoneColor == Stone.StoneColorList.White);
        public int BlackStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone.StoneColor == Stone.StoneColorList.Black);
        public int NoneStone => ReversiBoard.Board.SelectMany(stone => stone).Count(stone => stone.StoneColor == Stone.StoneColorList.None);

        //おかしい値の時にTrue を返す
        public bool IsBoardRange(int x, int y) => x <= 0 && x >= ReversiBoard.Board.Length && y <= 0 && y >= ReversiBoard.Board.Length;
      
        public Stone GetStone(int x, int y) => ReversiBoard.Board[x][y];
        
        public Stone.StoneColorList GetEnemyColor(Stone stone) => stone.StoneColor == Stone.StoneColorList.Black
            ? Stone.StoneColorList.White
            : Stone.StoneColorList.Black;

        public bool SetStone(Stone stone)
        {
            if (stone == null) return false;
            if (GetStone(stone.X, stone.Y).StoneColor != Stone.StoneColorList.None) return false;
            if (IsChangeStoneColor(stone)) return false;
            if (!IsBoardRange(stone.X, stone.Y)) return false;
            ReversiBoard.Board[stone.X][stone.Y] = stone;
            return true;
        }

        public bool IsChangeStoneColor(Stone nowstone)
        {
            if (IsBoardRange(nowstone.X, nowstone.Y)) return false;

            if (GetEnemyColor(nowstone) == GetTopStone(nowstone).StoneColor &&
                GetEnemyColor(nowstone) == GetUnderStone(nowstone).StoneColor) return true;

            if (GetEnemyColor(nowstone) == GetRightStone(nowstone).StoneColor &&
                GetEnemyColor(nowstone) == GetLeftStone(nowstone).StoneColor) return true;

            return false;
        }

        protected Stone GetTopStone(Stone stone) =>
            IsBoardRange(stone.X++, stone.Y) ? null : ReversiBoard.Board[stone.X - 1][stone.Y];

        protected Stone GetUnderStone(Stone stone) =>
            IsBoardRange(stone.X--, stone.Y) ? null : ReversiBoard.Board[stone.X + 1][stone.Y];

        protected Stone GetRightStone(Stone stone) =>
            IsBoardRange(stone.X, stone.Y++) ? null : ReversiBoard.Board[stone.X][stone.Y - 1];

        protected Stone GetLeftStone(Stone stone) =>
            IsBoardRange(stone.X, stone.Y--) ? null : ReversiBoard.Board[stone.X][stone.Y + 1];

        public bool IsContinue() => BlackStone != 0 && WhiteStone != 0;
    }

}