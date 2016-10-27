namespace Reversi.classes
{
    public class ScoreData
    {
        public int BlackScore { get; set; }
        public int WhiteScore { get; set; }

        public ScoreData(int blackScore, int whiteScore)
        {
            BlackScore = blackScore;
            WhiteScore = whiteScore;
        }
    }
}
