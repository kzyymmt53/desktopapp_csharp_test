using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimpleAlarm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        /// <summary>
        /// アラーム時刻チェック用タイマー
        /// </summary>
        private readonly DispatcherTimer _timer = new();
        public MainWindow()
        {
            InitializeComponent();
            タイマー初期化();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!入力時刻の検証(TimeInput.Text))
            {
                // 入力内容不正なので処理打ち切り
                return;
            }

            // アラーム一覧に時刻を追加
            AlarmList.Items.Add(TimeInput.Text);
            // 時刻コンボボックスの入力値クリア
            TimeInput.Text = "";

            // タイマーを開始していなければ開始
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
         
       
        }

        private bool 入力時刻の検証(string text, bool isSilent = false)
        {
            #region ローカル関数定義

            void エラー表示して入力項目にフォーカス設定(string msg)
            {
                if (isSilent)
                {
                    return;
                }
                // エラーメッセージ表示
                MsgBox.ShowErr(msg);
                // 時刻入力にフォーカス設定
                TimeInput.Focus();
            }

            #endregion

            // 入力されているか確認
            if (string.IsNullOrEmpty(text))
            {
                エラー表示して入力項目にフォーカス設定("追加する時刻を設定してください。");
                return false;
            }

            // 時刻として正しいか確認
            if (!Regex.IsMatch(text, "^[0-9]{2}:[0-9]{2}$") ||
                !DateTime.TryParse(text, out _))
            {
                エラー表示して入力項目にフォーカス設定("正しい時刻を設定してください。");
                return false;
            }

            // 重複確認
            if (AlarmList.Items
                .Cast<string>()
                .Any(item => item == text))
            {
                エラー表示して入力項目にフォーカス設定("追加済みの時刻です。");
                return false;
            }

            // チェックOK
            return true;
          
        }

        private void タイマー初期化()
        {
            // イベント発生間隔の設定
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            // イベント登録
            _timer.Tick += (_, _) =>
            {
                // アラーム一覧の時刻を1つずつ確認していく
                foreach (var item in AlarmList.Items)
                {
                    // 時刻を文字列で取得
                    string timeStr = item?.ToString() ?? "";

                    // 現在時刻と比較
                    if (DateTime.Now.ToString("HH:mm") == timeStr)
                    {
                        // アラーム一覧から該当時刻を削除
                        AlarmList.Items.Remove(item);

                        通知表示(timeStr);

                        break;
                    }
                }

                if (AlarmList.Items.IsEmpty)
                {
                    // アラーム一覧が空ならタイマー停止
                    _timer.Stop();
                }
            };
        }
        private void 通知表示(string timeStr)
        {
            // 通知ウィンドウ生成
            var window = new NotifyWindow();
            // 表示するメッセージ設定
            window.Message.Text = $"{timeStr} になりました";

            // 通知ウィンドウ表示
            window.Show();

            // ミュートがOFFか
            if (Mute.IsChecked != true)
            {
                // システムサウンドを鳴らす
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // アラーム一覧で項目が選択されているか確認
            if (AlarmList.SelectedIndex == -1)
            {
                MsgBox.ShowErr("削除するアイテムを選択してください。");
            }
            else
            {
                // 一覧から選択項目を削除
                AlarmList.Items.RemoveAt(AlarmList.SelectedIndex);

                // 一覧にまだ項目があるか確認
                if (AlarmList.Items.IsEmpty)
                {
                    // 一覧が空なのでタイマー停止
                    _timer.Stop();
                }
                else
                {
                    // 一覧の先頭項目を選択
                    AlarmList.SelectedIndex = 0;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveButton.IsEnabled = false;
                アラーム一覧保存(App.AlarmInitFilePath);
            }
            catch (Exception ex)
            {
                MsgBox.ShowErr(ex.ToString());
            }
            finally
            {
                SaveButton.IsEnabled = true;
            }
        }

        private void アラーム一覧保存(string alarmInitFilePath)
        {
            if (AlarmList.Items.IsEmpty)
            {
                MsgBox.ShowErr("保存する時刻がありません。");
                return;
            }

            using var writer = new StreamWriter(alarmInitFilePath, append: false, encoding: Encoding.UTF8);

            foreach (var item in AlarmList.Items)
            {
                writer.WriteLine(item);
            }

            MsgBox.ShowInfo($"{App.AlarmInitFilePath}を保存しました。");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                アラーム一覧読み込み(App.AlarmInitFilePath);
            }
            catch (Exception ex)
            {
                MsgBox.ShowErr(ex.ToString());
            }
        }

        private void アラーム一覧読み込み(string alarmInitFilePath)
        {
            if (!File.Exists(alarmInitFilePath))
            {
                // ファイルがなければ何もしない
                return;
            }

            AlarmList.Items.Clear();

            using var reader = new StreamReader(alarmInitFilePath, Encoding.UTF8);

            while (!reader.EndOfStream)
            {
                string timeStr = reader.ReadLine() ?? "";

                if (入力時刻の検証(timeStr, isSilent: true))
                {
                    // アラーム一覧に追加
                    AlarmList.Items.Add(timeStr);
                }
            }

            // タイマーを開始していなければ開始
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
        }
    }

}
