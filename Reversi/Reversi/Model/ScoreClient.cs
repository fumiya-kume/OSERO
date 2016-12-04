using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;
using Prism.Mvvm;
using Reactive.Bindings;
using Reversi.Model.classes;

namespace Reversi.Model
{
    public class ScoreClient : SettingHelper
    {
        public ReactiveCollection<ScoreData> ScoreData { get; set; } = new ReactiveCollection<ScoreData>();

        public void AddScore(ScoreData scoreData)
        {
            ScoreData.Add(scoreData);
            base.SaveSetting(ScoreData);
        }

        public async void LoadScore()
        {
            (await base.LoadSettings<List<ScoreData>>())
                .ForEach(data =>ScoreData.Add(data));
        }
    }
}
