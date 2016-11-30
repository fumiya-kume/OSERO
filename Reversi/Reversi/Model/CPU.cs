using System;
using System.Linq;
using Reversi.classes;
using Reversi.Extentison;

namespace Reversi.Model
{
    public class CPU
    {
        public CPU(ReversiBoard boarddata)
        {
            if (boarddata == null) throw new NullReferenceException();
            BoardData = boarddata;
        }

        public ReversiBoard BoardData { get; set; }

        public ColorPoint GetShouldSetPoint(classes.Player player)
            => BoardData.GetEnableColorPointList(player)
                .Select(
                    colorpoint => { return new ColorData(colorpoint, GetEvaluationValue(colorpoint)); })
                .FindMax(c => c.Score).point;

        private int GetEvaluationValue(ColorPoint point)
        {
            int[][] EvaluatioMap =
            {
                new[] {30, -12, 0, -1, -1, 0, -12, 30},
                new[] {-12, -15, -3, -3, -3, -3, -15, -12},
                new[] {0, -3, 0, -1, -1, 0, -3, 0},
                new[] {-1, 3, -1, -1, -1, -1, -3, -1},
                new[] {-1, 3, -1, -1, -1, -1, -3, -1},
                new[] {0, -3, 0, -1, -1, 0, -3, 0},
                new[] {-12, -15, -3, -3, -3, -3, -15, -12},
                new[] {30, -12, 0, -1, -1, 0, -12, 30}
            };
            return EvaluatioMap[point.x][point.y];
        }
    }
}