namespace Reversi.classes
{
    public class ColorPosition
    {
        public ColorPosition(int x, int y, Player player)
        {
            this.x = x;
            this.y = y;
            Player = player;
        }

        public int x { get; set; }
        public int y { get; set; }
        public Player Player { get; set; }
    }
}