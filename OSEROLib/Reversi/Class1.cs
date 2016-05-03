using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Reversi;

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
        public bool CheckBoardPointRange(int x, int y) => x <= 0 && x >= Board.Length && y <= 0 && y >= Board.Length;

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

        public Stone.StoneColorList GetEnemyStoneColor(Stone stone) => stone.StoneColor == Stone.StoneColorList.Black
            ? Stone.StoneColorList.White
            : Stone.StoneColorList.Black;

        public bool PutStone(Stone stone)
        {
            if (stone == null) return false;
            if (ReversiBoard.GetStone(stone.X,stone.Y).StoneColor != Stone.StoneColorList.None) return false;
            if (IsChangeStoneColor(stone)) return false;
            if(!ReversiBoard.CheckBoardPointRange(stone.X,stone.Y)) return false;

            ReversiBoard.PutStone(stone);
            
            return true;
        }

        public bool IsChangeStoneColor(Stone nowstone)
        {
            if (ReversiBoard.CheckBoardPointRange(nowstone.X, nowstone.Y)) return false;

            if (GetEnemyColor(nowstone) == GetTopStone(nowstone).StoneColor &&
                GetEnemyColor(nowstone) == GetUnderStone(nowstone).StoneColor) return true;

            if (GetEnemyColor(nowstone) == GetRightStone(nowstone).StoneColor &&
                GetEnemyColor(nowstone) == GetLeftStone(nowstone).StoneColor) return true;

            return false;
        }

        /// <summary>
        /// 敵の石の色を取得する
        /// </summary>
        /// <param name="nowColorList">現在の石の色</param>
        /// <returns>敵の色の情報</returns>
        public Stone.StoneColorList GetEnemyColor(Stone nowColorList) =>
            nowColorList.StoneColor == Stone.StoneColorList.Black ?
            Stone.StoneColorList.White : Stone.StoneColorList.Black;

        /// <summary>
        /// 上の石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>上にある石の情報</returns>
        protected Stone GetTopStone(Stone nowStone)
            => nowStone.Y == 0
            ? new Stone() : ReversiBoard.Board[nowStone.X][nowStone.Y - 1];

        /// <summary>
        /// 下にある石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>下にある石の情報</returns>
        protected Stone GetUnderStone(Stone nowStone)
            => nowStone.Y == ReversiBoard.Board.Length
            ? new Stone() : ReversiBoard.Board[nowStone.X][nowStone.Y + 1];

        /// <summary>
        /// 右にある石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>右にある石の情報</returns>
        protected Stone GetRightStone(Stone nowStone)
            => nowStone.X == 0
            ? new Stone() : ReversiBoard.Board[nowStone.X + 1][nowStone.Y];

        /// <summary>
        /// 左にある石の情報
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>左にある石の情報</returns>
        protected Stone GetLeftStone(Stone nowStone)
            => nowStone.X == ReversiBoard.Board[0].Length
            ? new Stone() : ReversiBoard.Board[nowStone.X - 1][nowStone.Y];
    }


}