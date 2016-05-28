using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiLib
{
    public class Player
    {
        public int SkipCounter { get; set; }
        public Color NowColor { get; set; }
        public void Change() => NowColor = Reversi.EnemyColor(NowColor);
        public void Skip()
        {
            SkipCounter++;
            Change();
        }

    }
}
