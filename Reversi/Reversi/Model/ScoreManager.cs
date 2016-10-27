using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.Devices.SmartCards;
using Newtonsoft.Json;
using Reversi.classes;
using static Windows.Storage.ApplicationData;

namespace Reversi.Model
{
    public static class ScoreManager
    {
        /// <summary>
        /// スコアを端末に保存する
        /// </summary>
        /// <param name="data"></param>
        public static void SaveScore(ScoreData data)
        {
            var Scores = new List<ScoreData>();
            if (Current.RoamingSettings.Values.ContainsKey("Score"))
            {
                Debug.Write(Current.RoamingSettings.Values["Score"] + "\n");
                Debug.Write("データの数");

                Scores = JsonConvert.DeserializeObject<List<ScoreData>>(Current.RoamingSettings.Values["Score"].ToString());
                if (Current.RoamingSettings.Values["Score"].ToString() == "")
                {
                    Scores = new List<ScoreData>();
                }
            }
            Scores.Add(data);
            Current.RoamingSettings.Values["Score"] = JsonConvert.SerializeObject(Scores);
        }

        /// <summary>
        /// 保存されているスコアの件数を返す。
        /// スコアが1件も保存されていないときは、-1を返す
        /// </summary>
        /// <returns></returns>
        public static int CountScore()
        {
            return Current.RoamingSettings.Values.ContainsKey("Score") ? LoadScores().Count : -1;
        }

        /// <summary>
        /// 保存されているスコアを読んで返す
        /// </summary>
        /// <returns></returns>
        public static List<ScoreData> LoadScores()
        {
            if (!Current.RoamingSettings.Values.ContainsKey("Score"))
            {
                return new List<ScoreData>();
            }
            return JsonConvert.DeserializeObject<List<ScoreData>>(Current.RoamingSettings.Values["Score"].ToString()) ?? new List<ScoreData>();

        }



        /// <summary>
        /// 保存されているスコアをすべて削除して初期化する
        /// </summary>
        public static void ClearScore()
        {
            Current.RoamingSettings.Values["Score"] = "";
        }
    }
}

