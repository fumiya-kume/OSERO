using System;
using Windows.UI.Xaml;

namespace Reversi.Model
{
    public class CountDownTimer
    {
        private int Secounds { get; }
        private int DefaultSecounds { get; }

        private DispatcherTimer Timer { get; } = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        public CountDownTimer(int secounds)
        {
            Secounds = secounds;
            DefaultSecounds = secounds;
            Timer.Tick += (sender, o) => secounds--;
        }

        public void Start()
        {
            Timer.Start();
        }

        public int NowTime() => Secounds;

        public void Stop()
        {
            Timer.Stop();
        }

        public void Reset()
        {
            Timer.Stop();
            Timer.Interval = TimeSpan.FromSeconds(DefaultSecounds);
        }
    }
}
