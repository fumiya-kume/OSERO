using Windows.UI.Xaml.Controls;
using Reactive.Bindings;
using Reversi.Model;
using Reversi.Model.classes;

namespace Reversi.ViewModel
{
    public class ScoreBoardPageViewModel:ViewModelBase
    {
        public ReactiveCollection<ScoreData> ScoreData { get; set; }

        private readonly ScoreClient _scoreClient = new ScoreClient();


        public ScoreBoardPageViewModel(Frame frame) : base(frame)
        {
            ScoreData = _scoreClient.ScoreData;
            _scoreClient.LoadScore();
        }
    }
}
