using Prism.Mvvm;
using RxReversi.classes;

namespace RxReversi.Model
{
    public class Player : BindableBase
    {
        public int SkipCounter { get; set; }

        public Player()
        {
            this.NowColor = Color.Black;
        }
        
        private Color _nowcolor;

        public Color NowColor
        {
            get { return _nowcolor; }
            set { SetProperty(ref _nowcolor, value); }
        }
        
        public void ChangePlayer()
        {
            NowColor = Util.EnemyColor(NowColor);
            SkipCounter = 0;
        }
        
        public void Skip()
        {
            SkipCounter++;
            ChangePlayer();
        }
    }
}