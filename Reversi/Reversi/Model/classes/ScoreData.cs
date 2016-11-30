namespace Reversi.classes
{
    public class ScoreData
    {
        public ScoreData(int blackScore, int whiteScore)
        {
            BlackScore = blackScore;
            WhiteScore = whiteScore;
        }

        public int BlackScore { get; set; }
        public int WhiteScore { get; set; }
    }
}