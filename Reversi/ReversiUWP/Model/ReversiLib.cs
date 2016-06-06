using ReversiUWP.classes;
using static ReversiUWP.classes.Color;

namespace ReversiUWP.Model
{
    public class ReversiLib
    {
        public ReversiBoard Board { get; set; } = new ReversiBoard();
        public Player Player { get; set; } = new Player();


    }
}
