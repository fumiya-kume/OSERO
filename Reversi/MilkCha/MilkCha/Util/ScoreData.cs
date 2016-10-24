using System;

namespace MilkCha.Util
{
    public class ScoreData : IScoreData
    {
        public long UID { get; set; }
        public DateTime BattleStartTime { get; set; }
        public DateTime BattleEndTime { get; set; }
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }
        public string CpuName { get; set; }
        public int CpuScore { get; set; }

        public ScoreData(long uid = -1, DateTime battleStartTime = new DateTime(), DateTime battleEndTime = new DateTime(), string playerName = "", int playerScore = -1, string cpuName = "", int cpuScore = -1)
        {
            UID = uid;
            BattleStartTime = battleStartTime;
            BattleEndTime = battleEndTime;
            PlayerName = playerName;
            PlayerScore = playerScore;
            CpuName = cpuName;
            CpuScore = cpuScore;
        }
    }
}
