﻿using System;
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
        public Exception NoneStoneException;

        public ReversiBoard()
        {
            BoardInfos = new[,]
            {
                { new StoneInfo {StonePositionX = 0,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 0},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 0}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 1},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 1}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 2},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 2}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 3},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 3}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 4},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 4}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 5},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 5}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 6},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 6}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 7},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 7}},
                { new StoneInfo {StonePositionX = 0,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 1,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 2,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 3,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 4,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 5,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 6,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 7,StonePositonY = 8},
                  new StoneInfo {StonePositionX = 8,StonePositonY = 8}}
            };
        }

        /// <summary>
        /// 上の石の情報を取得する
        /// </summary>
        /// <param name="nowStone">起点となる石の情報</param>
        /// <returns></returns>
        public StoneInfo GetTopStoneInfo(StoneInfo nowStone)
        {
            if (nowStone.StonePositonY == 0) throw NoneStoneException;
            return BoardInfos[nowStone.StonePositionX, nowStone.StonePositonY - 1];
        }
        public StoneInfo GetUnderStoneInfo(StoneInfo nowStone)
        {
            if (nowStone.StonePositonY == BoardInfos.GetLength(1)) throw NoneStoneException;
            return BoardInfos[nowStone.StonePositionX, nowStone.StonePositonY + 1];
        }
        public StoneInfo GetRightStoneInfo(StoneInfo nowStone)
        {
            if (nowStone.StonePositionX == BoardInfos.GetLength(1)) throw NoneStoneException;
            return BoardInfos[nowStone.StonePositionX + 1, nowStone.StonePositonY];
        }
        public StoneInfo GetLeftStoneInfo(StoneInfo nowStone)
        {
            if (nowStone.StonePositionX == 0) throw NoneStoneException;
            return BoardInfos[nowStone.StonePositionX - 1, nowStone.StonePositonY];
        }
    }

    public struct StoneInfo
    {
        public int StoneColor { get; set; }
        public int StonePositionX { get; set; }
        public int StonePositonY { get; set; }
    }
}
