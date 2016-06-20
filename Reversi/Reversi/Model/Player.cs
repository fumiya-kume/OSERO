using Reversi.classes;

namespace Reversi.Model
{
    public class Player
    {
        public int SkipCounter { get; set; }
        public Color NowColor { get; set; } = Color.Black;

        public void ChangePlayer()
        {
            NowColor = Util.EnemyColor(NowColor);
            SkipCounter = 0;
        }

        public bool IsEndGame()
            => SkipCounter >= 2;
        
        public void Skip()
        {
            SkipCounter++;
            ChangePlayer();
        }
    }
}