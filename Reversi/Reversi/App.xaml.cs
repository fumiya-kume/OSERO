using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows;
using Reversi.ViewModels;
using Reversi.Views;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;
using Reversi.Model;

namespace Reversi
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