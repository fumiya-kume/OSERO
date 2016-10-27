using Reversi.classes;

namespace Reversi.Model
{
    public class Player
    {
        private int SkipCounter { get; set; }
        public classes.Player NowPlayer { get; set; } = classes.Player.Black;

        public void ChangePlayer()
        {
            NowPlayer = Util.EnemyColor(NowPlayer);
            SkipCounter = 0;
        }

        public void Init()
        {
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