using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Reactive.Bindings.Interactivity;
using RxReversi.classes;
using RxReversi.Control;

namespace RxReversi.Util
{
    public class Converters
    {
        public class TappedEventArgToColorPosition : ReactiveConverter<BoardTappedArgs, ColorPoint>
        {
            protected override IObservable<ColorPoint> OnConvert(IObservable<BoardTappedArgs> source)
                => source.Select(args => new ColorPoint(args.ColorPoint.x, args.ColorPoint.y));
            
        }
    }

    public class TapPositionConverter : ReactiveConverter<TappedRoutedEventArgs, Point>
    {
        protected override IObservable<Point> OnConvert(IObservable<TappedRoutedEventArgs> source)
            => source
            .Select(arg => arg.GetPosition((UIElement)AssociateObject));
    }

}
