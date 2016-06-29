using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace RxReversi.ViewModels
{
    public class GamePageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public GamePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
