using System;

namespace Reversi.classes
{
    public class ColorData
    {
        public ColorData(Tuple<int,int> point, int score)
        {
            this.Point = point;
            Score = score;
        }

        public Tuple<int,int> Point { get; set; }
        public int Score { get; set; }
    }
}