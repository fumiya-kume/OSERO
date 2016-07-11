using System;
using System.Reactive.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Reactive.Bindings.Interactivity;

namespace RxReversi.Converters
{
    public class TapPositionConverter:ReactiveConverter<TappedRoutedEventArgs, Point>
    {
        protected override IObservable<Point> OnConvert(IObservable<TappedRoutedEventArgs> source) 
            => source
            .Select(arg => arg.GetPosition((UIElement) AssociateObject));
    }
}
