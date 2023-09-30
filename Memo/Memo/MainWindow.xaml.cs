using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Memo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            // 「ファイルを開く」ダイアログ生成
            var dialog = new OpenFileDialog();
            // ファイルの種類
            dialog.Filter = "テキスト ドキュメント (*.txt)|*.txt|すべてのファイル (*.*)|*.*";

            // ダイアログを表示（ファイルが選択されて「開く」が押されたらtrueが返ってくる）
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    IsEnabled = false;

                    await LoadFileToMemoAsync(dialog.FileName);

                    // ステータスバー更新
                    StatusInfo.Content = $"{dialog.FileName} を開きました。";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    IsEnabled = true;
                }
            }
        }

        private async void SaveAsMenu_Click(object sender, RoutedEventArgs e)
        {
            // 「名前を付けて保存」ダイアログ生成
            var dialog = new SaveFileDialog
            {
                // ファイルの種類
                Filter = "テキスト ドキュメント (*.txt)|*.txt|すべてのファイル (*.*)|*.*",
                // 既定の拡張子
                DefaultExt = "txt",
                // ファイル上書き警告表示
                OverwritePrompt = true
            };

            // ダイアログを表示（ファイルを指定して「保存」が押されたらtrueが返ってくる）
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    IsEnabled = false;

                    using var writer = new StreamWriter(
                        dialog.FileName,
                        append: false,
                        encoding: Encoding.UTF8);

                    // TextBoxの内容をファイル出力
                    await writer.WriteAsync(Memo.Text);

                    // ステータスバー更新
                    StatusInfo.Content = $"{dialog.FileName} を保存しました。";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    IsEnabled = true;
                }
            }
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextSizeMenu_Click(object sender, RoutedEventArgs e)
        {
            Memo.FontSize = Zoom.IsChecked == true ? 36 : 12;
        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("バージョン 0.01", "メモ");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(Memo.Text))
            {
                if (MessageBox.Show(
                    "入力がありますが、終了しますか？",
                    "確認",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) != MessageBoxResult.Yes)
                {
                    // 終了をキャンセル
                    e.Cancel = true;
                }

                // 「はい」が押されたら普通に終了
            }
        }

        /// <summary>
        /// ファイルを読み込んで内容を画面のTextBoxに設定
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private async Task LoadFileToMemoAsync(string filePath)
        {
            using var reader = new StreamReader(
                filePath,
                encoding: Encoding.UTF8);

            // 読み込んだ内容をTextBoxに設定
            Memo.Text = await reader.ReadToEndAsync();
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            try
            {
                LoadAppSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadAppSettings()
        {
            const double MinWindowSize = 150;
            const double MaxWindowSize = 800;
            const double DefWindowSize = 400;

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(App.AppSettingsFile, optional: true, reloadOnChange: false)
                .Build();

            // 設定読み込み
            IConfigurationSection section = config.GetSection("Window");
            Title = section.GetValue<string>("Title", "メモ");
            double h = section.GetValue<double>("InitHeight", DefWindowSize);
            double w = section.GetValue<double>("InitWidth", DefWindowSize);

            // ウィンドウ高さ設定
            Height = (h is < MinWindowSize or > MaxWindowSize)
                ? DefWindowSize
                : h;

            // ウィンドウ幅設定
            Width = (w is < MinWindowSize or > MaxWindowSize)
                ? DefWindowSize
                : w;
        }
    }
}
