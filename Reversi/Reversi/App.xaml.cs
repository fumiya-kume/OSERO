using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;
using Prism.Unity.Windows;

namespace MilkCha
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