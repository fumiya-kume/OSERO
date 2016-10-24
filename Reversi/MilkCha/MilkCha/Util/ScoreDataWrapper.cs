namespace MilkCha.Util
{
    public class ScoreDataWrapper : IScoreDataWrapper
    {
        public ScoreData LoadScoreData()
        {
            return new ScoreData();
        }

        public bool SaveScoreData(ScoreData scoreData)
        {
            return true;
        }

        public bool ResetScoreData()
        {
            return true;
        }

        public bool DeleteScoreData(int UID)
        {
            return true;
        }
    }
}
