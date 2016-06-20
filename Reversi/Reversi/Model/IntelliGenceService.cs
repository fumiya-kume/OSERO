using Reversi.classes;
using Reversi.Extentison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reversi.Model.ReversiLib;

namespace Reversi.Model
{
    public class IntelliGenceService
    {
        public ReversiBoard BoardData { get; set; }
        public IntelliGenceService(ReversiBoard boarddata)
        {
            if (boarddata == null) throw new NullReferenceException();
            BoardData = boarddata;
        }

        public ColorData GetShouldSetPoint(Color color)
        {
            var result = BoardData.GetEnableColorPointList(color)
                .Select(colorpoint =>
                {
                    return new ColorData() { point = colorpoint, Score = GetEvaluationValue(colorpoint) };
                })
                //スコアの一番大きな要素を返す
                .FindMax(c => c.Score);
            return result;
        }

        private int GetEvaluationValue(ColorPoint point)
        {
            int[][] EvaluatioMap =
        {
            new[] { 30, -12, 0, -1, -1, 0, -12, 30 },
            new[] { -12, -15, -3, -3, -3, -3, -15, -12 },
            new[] { 0, -3, 0, -1, -1, 0, -3, 0 },
            new[] { -1, 3, -1, -1, -1, -1, -3, -1 },
            new[] { -1, 3, -1, -1, -1, -1, -3, -1 },
            new[] { 0, -3, 0, -1, -1, 0, -3, 0 },
            new[] { -12, -15, -3, -3, -3, -3, -15, -12 },
            new[] { 30, -12, 0, -1, -1, 0, -12, 30 }
        };
            return EvaluatioMap[point.x][point.y];
        }
    }
}
