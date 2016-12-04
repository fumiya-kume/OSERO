namespace MilkCha.Util
{
    public interface IScoreDataWrapper
    {
        bool DeleteScoreData(int UID);
        ScoreData LoadScoreData();
        bool ResetScoreData();
        bool SaveScoreData(ScoreData scoreData);
    }
}