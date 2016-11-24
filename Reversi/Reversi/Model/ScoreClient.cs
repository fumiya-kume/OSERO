using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reversi.classes;

namespace Reversi.Model
{
    public class ScoreClient : SettingHelper
    {
        public async Task AddScore(ScoreData scoreData)
        {
            var scoreDatas = await LoadAllScores();
            scoreDatas.Add(scoreData);
            base.SaveSetting(scoreDatas);
        }

        public async Task<List<ScoreData>> LoadAllScores()
        {
            return await base.LoadSettings<List<ScoreData>>();
        }
    }
}
