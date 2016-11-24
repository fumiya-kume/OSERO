using System;
using System.Diagnostics;
using System.Threading.Tasks;
using static Windows.Storage.ApplicationData;
using static Newtonsoft.Json.JsonConvert;

namespace Reversi.Model
{
    public class SettingHelper
    {
        public SettingHelper(string key = "Score")
        {
            Key = key;
        }

        /// <summary>
        ///     キーの値が保存されているかを確かめる
        /// </summary>
        private bool IsContainSetting => Current.RoamingSettings.Values.ContainsKey(Key) && LoadSetting != "\"\"";

        /// <summary>
        ///     設定を読み込む
        /// </summary>
        private string LoadSetting => Current.RoamingSettings.Values[Key].ToString() ?? "";

        /// <summary>
        ///     保存した設定を掘り起こすキー
        /// </summary>
        private string Key { get; }

        /// <summary>
        ///     設定を保存する
        /// </summary>
        /// <param name="data"></param>
        protected void SaveSetting(object data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            Current.RoamingSettings.Values[Key] = SerializeObject(data);
        }

        /// <summary>
        ///     保存されているスコアを読んで返す
        /// </summary>
        /// <returns></returns>
        protected async Task<T> LoadSettings<T>() where T : new()
        {
            return IsContainSetting
                ? await Task.Run(() => DeserializeObject<T>(LoadSetting))
                : new T();
        }

        /// <summary>
        ///     保存されているスコアをすべて削除して初期化する
        /// </summary>
        public void ClearScore() => SaveSetting("");
    }
}