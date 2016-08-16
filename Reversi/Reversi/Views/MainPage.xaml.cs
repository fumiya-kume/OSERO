using System;
using Windows.UI.Notifications;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Reversi.ViewModels;

namespace Reversi.Views
{
    public sealed partial class MainPage : SessionStateAwarePage
    {
        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;
        public MainPage()
        {
            this.InitializeComponent();

            DataContextChanged += (sender, args) =>
            {
                ViewModel.navigationService = new FrameNavigationService(
                    new FrameFacadeAdapter(ViewFrame),
                    s => Type.GetType(this.GetType().Namespace + $".{s}Page"),
                    new SessionStateService());
            };
        }
    }
}

