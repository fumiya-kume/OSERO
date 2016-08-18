using System.Diagnostics;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Prism.Windows.Mvvm;
using Reactive.Bindings;

namespace Reversi.ViewModels
{
    public class GamePageViewModel:ViewModelBase
    {
        public void CanvasTapped(object obj, TappedRoutedEventArgs args)
        {
            //Debug.Write($"tapped{args.GetPosition((Canvas)obj)}");
        }

        public ReactiveProperty<string> Greeting { get; set; } = new ReactiveProperty<string>("Hello World!!");
    }
}
