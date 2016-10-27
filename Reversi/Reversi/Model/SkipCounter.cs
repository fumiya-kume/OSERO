namespace Reversi.Model
{
    public class SkipCounter
    {
        public int Counter { get; set; } = 0;
        public void Skip()
        {
            Counter++;
        }

        public void InIt()
        {
            Counter = 0;
        }

        public bool IsContinue() => Counter < 3;
    }
}
