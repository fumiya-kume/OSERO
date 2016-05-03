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
        private Stone[][] Board { get; } = {
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()}
            };

        public int WhiteStone => Board.Sum(t => t.Count(stone => stone.StoneColor == Stone.StoneColorList.White));
        public int BlackStone => Board.Sum(t => t.Count(stone => stone.StoneColor == Stone.StoneColorList.Black));
        public int NoneStone => Board.Sum(t => t.Count(stone => stone.StoneColor == Stone.StoneColorList.None));

        //おかしい値の時にTrue を返す
        public bool IsBoardRange(int x, int y) => x <= 0 && x >= Board.Length && y <= 0 && y >= Board.Length;

        public Stone GetTopStone(Stone stone) => Board[stone.X - 1][stone.Y];
        public Stone GetUnderStone(Stone stone) => Board[stone.X + 1][stone.Y];
        public Stone GetRightStone(Stone stone) => Board[stone.X][stone.Y - 1];
        public Stone GetLeftStone(Stone stone) => Board[stone.X][stone.Y + 1];

        public void PutStone(Stone stone) => Board[stone.X][stone.Y] = stone;
        public Stone GetStone(int x, int y) => Board[x][y];
    }

    public class ReversiLib
    {
        public ReversiBoard ReversiBoard { get; } = new ReversiBoard();

        public Stone.StoneColorList GetEnemyColor(Stone stone) => stone.StoneColor == Stone.StoneColorList.Black
            ? Stone.StoneColorList.White
            : Stone.StoneColorList.Black;

        public bool PutStone(Stone stone)
        {
            if (stone == null) return false;
            if (ReversiBoard.GetStone(stone.X, stone.Y).StoneColor != Stone.StoneColorList.None) return false;
            if (IsChangeStoneColor(stone)) return false;
            if (!ReversiBoard.IsBoardRange(stone.X, stone.Y)) return false;

            ReversiBoard.PutStone(stone);
            return true;
        }

        public bool IsChangeStoneColor(Stone nowstone)
        {
            if (ReversiBoard.IsBoardRange(nowstone.X, nowstone.Y)) return false;

            if (GetEnemyColor(nowstone) == GetTopStone(nowstone).StoneColor &&
                GetEnemyColor(nowstone) == GetUnderStone(nowstone).StoneColor) return true;

            if (GetEnemyColor(nowstone) == GetRightStone(nowstone).StoneColor &&
                GetEnemyColor(nowstone) == GetLeftStone(nowstone).StoneColor) return true;

            return false;
        }

        protected Stone GetTopStone(Stone nowStone) =>
            ReversiBoard.IsBoardRange(nowStone.X++, nowStone.Y) ? null : ReversiBoard.GetStone(nowStone.X++, nowStone.Y);

        protected Stone GetUnderStone(Stone nowStone) =>
            ReversiBoard.IsBoardRange(nowStone.X--, nowStone.Y) ? null : ReversiBoard.GetStone(nowStone.X--, nowStone.Y);
        
        protected Stone GetRightStone(Stone nowStone) =>
            ReversiBoard.IsBoardRange(nowStone.X, nowStone.Y++) ? null : ReversiBoard.GetStone(nowStone.X, nowStone.Y++);

        protected Stone GetLeftStone(Stone nowStone) =>
            ReversiBoard.IsBoardRange(nowStone.X, nowStone.Y--) ? null : ReversiBoard.GetStone(nowStone.X, nowStone.Y--);

        public bool IsContinue() => ReversiBoard.BlackStone != 0 && ReversiBoard.WhiteStone != 0;
    }


}