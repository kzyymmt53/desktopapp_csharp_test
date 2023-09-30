using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAlarm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string AlarmInitFileName = "時刻初期データ.txt";

        /// <summary>
        /// 時刻初期データファイルパス
        /// </summary>
        public static string AlarmInitFilePath
        {
            get
            {
                // アプリケーションのパス取得
                string? appPath = AppContext.BaseDirectory;
                if (appPath is null)
                {
                    throw new DirectoryNotFoundException("実行ファイルのパス取得失敗");
                }

                // パスとファイル名を結合して返す
                return Path.Combine(appPath, AlarmInitFileName);
            }
        }
    }
}
