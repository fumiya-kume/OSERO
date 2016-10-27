namespace Reversi.classes
{
    public class ColorData
    {
        public ColorData(ColorPoint point, int score)
        {
            this.point = point;
            Score = score;
        }

        public ColorPoint point { get; set; }
        public int Score { get; set; }
    }
}