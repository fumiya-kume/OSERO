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

        public ReactiveProperty<string> NowColor { get; set; }
        
        public GamePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            
            NowColor = Player
                .ObserveProperty(c => c.NowColor)
                .Select(c => c.ToString())
                .ToReactiveProperty();
        }
    }
}
