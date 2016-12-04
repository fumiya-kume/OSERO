using MilkCha.Util;
using Prism.Mvvm;

namespace MilkCha.Model
{
    public class TurnManager : BindableBase
    {
        private PlayerList _player;
        public PlayerList Player
        {
            get { return _player; }
            set { SetProperty(ref _player, value); }
        }

        public void Switch() => Player = Util.Util.EnemyColor(Player);
    }
}
