using ReversiLib;

namespace Reversi
{
    public class Player
    {
        public int SkipCounter { get; set; }
        public Color NowColor { get; set; } = Color.Black;

        public void Change()
        {
            var enemy = global::Reversi.Util.EnemyColor(NowColor);
            NowColor = enemy;
        }
        public void Skip()
        {
            SkipCounter++;
            Change();
        }

    }
}
