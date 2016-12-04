using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows;
using RxReversi.ViewModels;
using RxReversi.Views;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;
using RxReversi.Model;

namespace RxReversi
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