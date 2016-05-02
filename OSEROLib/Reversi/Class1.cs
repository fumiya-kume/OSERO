using System.Linq;

namespace Reversi
{
    public class ReversiLib
    {
        public Stone[][] Board { get; } = {
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()},
                new[] {new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone(), new Stone()}
            };

        /// <summary>
        /// 石が置けた場合はTrue を返す
        /// </summary>
        /// <param name="stone"></param>
        /// <returns></returns>
        public bool PutStone(Stone stone)
        {
            if (stone == null) return false;
            if (Board[stone.X][stone.Y].StoneColor != Stone.StoneColorList.None) return false;
            if (IsChangeStoneColor(stone)) return false;
            //数字がおかしかったらダメよ！
            if (stone.X < 0 || stone.X > 8) return false;
            if (stone.Y < 0 || stone.Y > 8) return false;

            Board[stone.X][stone.Y] = stone;
            return true;
        }


        /// <summary>
        /// 石の色が変化するか判定する
        /// </summary>
        /// <param name="nowstone">判定元となる石の情報</param>
        /// <returns>石の色を変更するかどうか</returns>
        public bool IsChangeStoneColor(Stone nowstone)
        {
            var enemyColor = GetEnemyStone(nowstone);

            if (enemyColor == GetTopStone(nowstone).StoneColor &&
                enemyColor == GetUnderStone(nowstone).StoneColor) return true;

            if (enemyColor == GetRightStone(nowstone).StoneColor &&
                enemyColor == GetLeftStone(nowstone).StoneColor) return true;

            return false;
        }

        /// <summary>
        /// 敵の石の色を取得する
        /// </summary>
        /// <param name="nowColorList">現在の石の色</param>
        /// <returns>敵の色の情報</returns>
        public Stone.StoneColorList GetEnemyStone(Stone nowColorList) =>
            nowColorList.StoneColor == Stone.StoneColorList.Black ?
            Stone.StoneColorList.White : Stone.StoneColorList.Black;

        /// <summary>
        /// 上の石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>上にある石の情報</returns>
        protected Stone GetTopStone(Stone nowStone)
            => nowStone.Y == 0
            ? new Stone() : Board[nowStone.X][nowStone.Y - 1];

        /// <summary>
        /// 下にある石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>下にある石の情報</returns>
        protected Stone GetUnderStone(Stone nowStone)
            => nowStone.Y == Board.Length
            ? new Stone() : Board[nowStone.X][nowStone.Y + 1];

        /// <summary>
        /// 右にある石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>右にある石の情報</returns>
        protected Stone GetRightStone(Stone nowStone)
            => nowStone.X == 0
            ? new Stone() : Board[nowStone.X + 1][nowStone.Y];

        /// <summary>
        /// 左にある石の情報
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>左にある石の情報</returns>
        protected Stone GetLeftStone(Stone nowStone)
            => nowStone.X == Board[0].Length
            ? new Stone() : Board[nowStone.X - 1][nowStone.Y];
    }

    public class Stone
    {
        public enum StoneColorList { None, White, Black }
        public StoneColorList StoneColor { get; set; } = StoneColorList.None;
        public int X { get; set; }
        public int Y { get; set; }
    }
}