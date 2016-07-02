using System.ComponentModel;
using RxReversi.classes;

namespace RxReversi.Model
{
    public class Player : INotifyPropertyChanged
    {
        public int SkipCounter { get; set; }

        public Player()
        {
            this.NowColor = Color.Black;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private Color _nowcolor;

        public Color NowColor
        {
            get { return _nowcolor; }
            set
            {
                _nowcolor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NowColor"));
            }
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