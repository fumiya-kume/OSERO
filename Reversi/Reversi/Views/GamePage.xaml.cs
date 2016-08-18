using Windows.UI.Notifications;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Reversi.ViewModels;

namespace Reversi.Views
{
    public sealed partial class GamePage : SessionStateAwarePage
    {
        public GamePageViewModel viewmodel => this.DataContext as GamePageViewModel;
        public GamePage()
        {
            this.InitializeComponent();
        }
    }
}

