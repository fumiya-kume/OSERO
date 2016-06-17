using ReversiUWP.classes;

namespace ReversiUWP.Model
{
    public class Player
    {
        public int SkipCounter { get; set; }
        public Color NowColor { get; set; } = Color.Black;

        public void Change()
        {
            NowColor = Util.EnemyColor(NowColor);
            SkipCounter = 0;
        }

        public void Skip()
        {
            SkipCounter++;
            Change();
        }
    }
}