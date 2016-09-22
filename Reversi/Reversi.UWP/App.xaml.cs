using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows;
using Reversi.UWP.ViewModels;
using Reversi.UWP.Views;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;
using Reversi.UWP.Model;

namespace Reversi.UWP
{
    [Bindable]
    public partial class App : PrismUnityApplication
    {
        public App() : base()
        {
            InitializeComponent();
        }


        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
            return Task.FromResult<object>(null);
        }
    }
}