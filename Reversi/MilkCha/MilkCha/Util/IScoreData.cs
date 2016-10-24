namespace MilkCha.Util
{
    public interface IScoreData
    {
        int CpuScore { get; set; }
        int PlayerScore { get; set; }
        long UID { get; set; }
    }
}