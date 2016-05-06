using System;
using System.IO;
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

        private StoneColorList GetEnemyColor(Stone stone) 
            => stone.StoneColor == StoneColorList.Black ? StoneColorList.White : StoneColorList.Black;

        public bool IsContinue() => BlackStone != 0 && WhiteStone != 0 && NoneStone != 0;
        private bool MatchBoard(int x, int y) => x <= 0 && x >= ReversiBoard.Board.Count() && y <= 0 && y >= ReversiBoard.Board[0].Length;
        private bool IsNone(Stone stone) => stone.StoneColor == StoneColorList.None;
        
        public Stone GetStone(int x, int y) => ReversiBoard.Board[x][y];
        public StoneColorList GetStoneColor(int x, int y) => GetStone(x, y).StoneColor;
        public bool SetStone(Stone stone)
        {
            if (MatchBoard(stone.X, stone.Y)) return false;
            if (!IsNone(ReversiBoard.Board[stone.X][stone.Y])) return false;
            if (IsChangeStoneColor(stone)) return false;

            ReversiBoard.Board[stone.X][stone.Y] = stone;
            if (IsChangeStoneColor(new Stone {X = stone.X, Y = stone.Y - 1, StoneColor = stone.StoneColor}))
                ReversiBoard.Board[stone.X][stone.Y - 1] = new Stone();
            return true;
        }

        private bool IsChangeStoneColor(Stone stone)
        {
            if (IsNone(stone)) return false;
            var enemyColor = GetEnemyColor(stone);

            if (MatchBoard(stone.X - 1, stone.Y) || MatchBoard(stone.X + 1, stone.Y))
            {
                if (enemyColor == GetStoneColor(stone.X - 1, stone.Y) &&
                enemyColor == GetStoneColor(stone.X + 1, stone.Y)) return true;
            }

            if (!MatchBoard(stone.X, stone.Y - 1) || !MatchBoard(stone.X, stone.Y + 1))
            {
                if (enemyColor == GetStoneColor(stone.X, stone.Y - 1) &&
                enemyColor == GetStoneColor(stone.X, stone.Y)) return true;
            }

            return false;
        }
    }
}