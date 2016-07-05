using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using RxReversi.classes;
using RxReversi.Model;

namespace RxReversi.ViewModels
{
    public class GamePageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public Player Player { get; set; } = new Player();
        public ReversiBoard Board { get; set; } = new ReversiBoard();

        public ReactiveProperty<string> NowColor { get; set; }
        public ReactiveProperty<string> BlackStone { get; set; }
        public ReactiveProperty<string> WhiteStone { get; set; }
        public ReactiveProperty<Color[][]> Colors { get; set; } 

        public GamePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            Board.Init();

            Colors = Board
                .ObserveProperty(c => c.Board)
                .ToReactiveProperty();

            NowColor = Player
                .ObserveProperty(c => c.NowColor)
                .Select(c => c.ToString())
                .ToReactiveProperty();

            BlackStone = Board
                .ObserveProperty(c => c.CountBlackColor)
                .Select(c => $"黒：{c}")
                .ToReactiveProperty();

            WhiteStone = Board
                .ObserveProperty(c => c.CountWhiteColor)
                .Select(c => $"白：{c}")
                .ToReactiveProperty();

            
        }
    }
}
