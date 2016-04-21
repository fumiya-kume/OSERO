using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSEROLib
{
    public class ReversiLib
    {
        
    }

    public class ReversiBoard
    {
        public StoneInfo[,] BoardData { get; set; }

        public Exception NoneStonException;


        public ReversiBoard()
        {
            BoardData = new StoneInfo[15,15]
            {
                {new StoneInfo{StonePointX = 0,StonePointY = 0},
                 new StoneInfo{StonePointX = 1,StonePointY = 0},
                 new StoneInfo{StonePointX = 1,StonePointY = 0},
                 new StoneInfo{StonePointX = 1,StonePointY = 0},
                 new StoneInfo{StonePointX = 1,StonePointY = 0},
                 new StoneInfo{StonePointX = 1,StonePointY = 0},
                 new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0},
                    new StoneInfo{StonePointX = 1,StonePointY = 0}},
                
            };
        }

        public StoneInfo GetTopStone(StoneInfo stoneInfo)
        {
            if (stoneInfo.StonePointY == 0) throw NoneStonException;


        }

        public StoneInfo GetUnderStone(StoneInfo stoneInfo)
        {

        }

        public StoneInfo GetRightStone(StoneInfo stoneInfo)
        {

        }

        public StoneInfo GetLeftStone(StoneInfo stoneInfo)
        {

        }
    }

    public struct StoneInfo
    {
        public int StoneColor { get; set; }
        public int StonePointX { get; set; }
        public int StonePointY { get; set; }
    }
}
