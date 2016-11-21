using System.Collections.Generic;
using System.Threading.Tasks;
using Reversi.classes;
using static Windows.Storage.ApplicationData;
using static Newtonsoft.Json.JsonConvert;

namespace Reversi.Model
{
    public class ScoreUtil
    {
        private ScoreUtil(string key = "Score")
        {
            Key = key;
        }

        /// <summary>
        /// キーの値が保存されているかを確かめる
        /// </summary>
        private static bool IsContainSetting => Current.RoamingSettings.Values.ContainsKey(Key);
        /// <summary>
        /// 設定を読み込む
        /// </summary>
        private static string LoadSetting => Current.RoamingSettings.Values[Key].ToString() ?? "";

        /// <summary>
        /// 保存した設定を掘り起こすキー
        /// </summary>
        private static string Key { get; set; }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        /// <param name="settings">保存したい設定</param>
        private static void SaveSetting(string settings)
            => Current.RoamingSettings.Values[Key] = DeserializeObject<List<ScoreData>>(settings);

        /// <summary>
        ///     スコアを端末に保存する
        /// </summary>
        /// <param name="data"></param>
        public static async Task SaveScore(ScoreData data)
        {
            await Task.Run(() =>
            {
                var scores = new List<ScoreData>();
                if (IsContainSetting)
                    scores = string.IsNullOrWhiteSpace(LoadSetting)
                        ? new List<ScoreData>()
                        : DeserializeObject<List<ScoreData>>(LoadSetting);
                scores.Add(data);
                SaveSetting(scores.ToString());
            });
        }

        /// <summary>
        ///     保存されているスコアの件数を返す。
        ///     スコアが1件も保存されていないときは、-1を返す
        /// </summary>
        /// <returns></returns>
        public static async Task<int> CountScore()
            => IsContainSetting ? (await LoadScores()).Count : -1;

        /// <summary>
        ///     保存されているスコアを読んで返す
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ScoreData>> LoadScores() => IsContainSetting
            ? await Task.Run(() => DeserializeObject<List<ScoreData>>(LoadSetting))
            : new List<ScoreData>();

        /// <summary>
        ///     保存されているスコアをすべて削除して初期化する
        /// </summary>
        public static void ClearScore() => SaveSetting("");
    }
}