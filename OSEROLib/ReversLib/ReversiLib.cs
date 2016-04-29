using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversLib
{
    public class ReversiLib
    {

    }

    public class ReversiBoard
    {
        public StoneInfo[,] BoardInfos { get; set; }

        public ReversiBoard()
        {
            #region StoneBoard
            BoardInfos = new[,]
            {
                { new StoneInfo {X = 0,Y = 0},
                  new StoneInfo {X = 1,Y = 0},
                  new StoneInfo {X = 2,Y = 0},
                  new StoneInfo {X = 3,Y = 0},
                  new StoneInfo {X = 4,Y = 0},
                  new StoneInfo {X = 5,Y = 0},
                  new StoneInfo {X = 6,Y = 0},
                  new StoneInfo {X = 7,Y = 0},
                  new StoneInfo {X = 8,Y = 0}},
                { new StoneInfo {X = 0,Y = 1},
                  new StoneInfo {X = 1,Y = 1},
                  new StoneInfo {X = 2,Y = 1},
                  new StoneInfo {X = 3,Y = 1},
                  new StoneInfo {X = 4,Y = 1},
                  new StoneInfo {X = 5,Y = 1},
                  new StoneInfo {X = 6,Y = 1},
                  new StoneInfo {X = 7,Y = 1},
                  new StoneInfo {X = 8,Y = 1}},
                { new StoneInfo {X = 0,Y = 2},
                  new StoneInfo {X = 1,Y = 2},
                  new StoneInfo {X = 2,Y = 2},
                  new StoneInfo {X = 3,Y = 2},
                  new StoneInfo {X = 4,Y = 2},
                  new StoneInfo {X = 5,Y = 2},
                  new StoneInfo {X = 6,Y = 2},
                  new StoneInfo {X = 7,Y = 2},
                  new StoneInfo {X = 8,Y = 2}},
                { new StoneInfo {X = 0,Y = 3},
                  new StoneInfo {X = 1,Y = 3},
                  new StoneInfo {X = 2,Y = 3},
                  new StoneInfo {X = 3,Y = 3},
                  new StoneInfo {X = 4,Y = 3},
                  new StoneInfo {X = 5,Y = 3},
                  new StoneInfo {X = 6,Y = 3},
                  new StoneInfo {X = 7,Y = 3},
                  new StoneInfo {X = 8,Y = 3}},
                { new StoneInfo {X = 0,Y = 4},
                  new StoneInfo {X = 1,Y = 4},
                  new StoneInfo {X = 2,Y = 4},
                  new StoneInfo {X = 3,Y = 4},
                  new StoneInfo {X = 4,Y = 4},
                  new StoneInfo {X = 5,Y = 4},
                  new StoneInfo {X = 6,Y = 4},
                  new StoneInfo {X = 7,Y = 4},
                  new StoneInfo {X = 8,Y = 4}},
                { new StoneInfo {X = 0,Y = 5},
                  new StoneInfo {X = 1,Y = 5},
                  new StoneInfo {X = 2,Y = 5},
                  new StoneInfo {X = 3,Y = 5},
                  new StoneInfo {X = 4,Y = 5},
                  new StoneInfo {X = 5,Y = 5},
                  new StoneInfo {X = 6,Y = 5},
                  new StoneInfo {X = 7,Y = 5},
                  new StoneInfo {X = 8,Y = 5}},
                { new StoneInfo {X = 0,Y = 6},
                  new StoneInfo {X = 1,Y = 6},
                  new StoneInfo {X = 2,Y = 6},
                  new StoneInfo {X = 3,Y = 6},
                  new StoneInfo {X = 4,Y = 6},
                  new StoneInfo {X = 5,Y = 6},
                  new StoneInfo {X = 6,Y = 6},
                  new StoneInfo {X = 7,Y = 6},
                  new StoneInfo {X = 8,Y = 6}},
                { new StoneInfo {X = 0,Y = 7},
                  new StoneInfo {X = 1,Y = 7},
                  new StoneInfo {X = 2,Y = 7},
                  new StoneInfo {X = 3,Y = 7},
                  new StoneInfo {X = 4,Y = 7},
                  new StoneInfo {X = 5,Y = 7},
                  new StoneInfo {X = 6,Y = 7},
                  new StoneInfo {X = 7,Y = 7},
                  new StoneInfo {X = 8,Y = 7}},
                { new StoneInfo {X = 0,Y = 8},
                  new StoneInfo {X = 1,Y = 8},
                  new StoneInfo {X = 2,Y = 8},
                  new StoneInfo {X = 3,Y = 8},
                  new StoneInfo {X = 4,Y = 8},
                  new StoneInfo {X = 5,Y = 8},
                  new StoneInfo {X = 6,Y = 8},
                  new StoneInfo {X = 7,Y = 8},
                  new StoneInfo {X = 8,Y = 8}}
            };
            #endregion

        }

        /// <summary>
        /// 石の色が変化するか判定する
        /// </summary>
        /// <param name="nowstoneInfo">判定元となる石の情報</param>
        /// <returns>石の色を変更するかどうか</returns>
        public bool IsChangeStoneColor(StoneInfo nowstoneInfo)
        {
            var EnemyColor = GetEnemyColor(nowstoneInfo.StoneColor);
            
            if (EnemyColor == GetTopStoneInfo(nowstoneInfo).StoneColor &&
                EnemyColor == GetUnderStoneInfo(nowstoneInfo).StoneColor) return true;

            if (EnemyColor == GetRightStoneInfo(nowstoneInfo).StoneColor &&
                EnemyColor == GetLeftStoneInfo(nowstoneInfo).StoneColor) return true;

            return false;
        }

        /// <summary>
        /// 敵の石の色を取得する
        /// </summary>
        /// <param name="nowColorList">現在の石の色</param>
        /// <returns>敵の色の情報</returns>
        public StoneInfo.StoneColorList GetEnemyColor(StoneInfo.StoneColorList nowColorList) 
        => nowColorList == StoneInfo.StoneColorList.Black
        ? StoneInfo.StoneColorList.White
        : StoneInfo.StoneColorList.Black;

        /// <summary>
        /// 上の石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>上にある石の情報</returns>
        protected StoneInfo GetTopStoneInfo(StoneInfo nowStone) 
        { 
        if(nowStone.Y == 0) return new StoneInfo();
       return BoardInfos[nowStone.X, nowStone.Y - 1];
        }
       
        /// <summary>
        /// 下にある石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>下にある石の情報</returns>
        protected StoneInfo GetUnderStoneInfo(StoneInfo nowStone) 
        => nowStone.Y == BoardInfos.GetLength(0)
            ? new StoneInfo()
            : BoardInfos[nowStone.X, nowStone.Y + 1];

        /// <summary>
        /// 右にある石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>右にある石の情報</returns>
        protected StoneInfo GetRightStoneInfo(StoneInfo nowStone) => nowStone.X == BoardInfos.GetLength(1)
            ? new StoneInfo()
            : BoardInfos[nowStone.X + 1, nowStone.Y];

        /// <summary>
        /// 左にある石の情報
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns>左にある石の情報</returns>
        protected StoneInfo GetLeftStoneInfo(StoneInfo nowStone) => nowStone.X == 0
            ? new StoneInfo()
            : BoardInfos[nowStone.X - 1, nowStone.Y];
    }

    public struct StoneInfo
    {
        public enum StoneColorList
        {
            None,
            White,
            Black
        }
        public StoneColorList StoneColor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        public StoneInfo()
        {
          StoneColor = StoneColorList.None;  
        }
    }
}