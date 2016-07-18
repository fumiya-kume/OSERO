using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings.Interactivity;
using RxReversi.classes;
using RxReversi.Control;

namespace RxReversi.Converters
{
    public class TappedEventArgToColorPosition : ReactiveConverter<BoardTappedArgs, ColorPoint>
    {
        protected override IObservable<ColorPoint> OnConvert(IObservable<BoardTappedArgs> source) 
            => source.Select(args => new ColorPoint(args.ColorPoint.x, args.ColorPoint.y));
    }
}
