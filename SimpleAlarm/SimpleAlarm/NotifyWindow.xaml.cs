using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleAlarm
{
    /// <summary>
    /// NotifyWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class NotifyWindow : Window
    {
        public NotifyWindow()
        {
            InitializeComponent();
            // ウィンドウ位置を左上に設定
            Left = 0;
            Top = 0;
            // ウィンドウサイズをスクリーンサイズに設定
            Width = SystemParameters.PrimaryScreenWidth;
            Height = SystemParameters.PrimaryScreenHeight;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // 「ESC」か「スペース」か「C」を押されたら終了
            if (e.Key is
                Key.Escape or
                Key.Space or
                Key.C)
            {
                Close();
            }
        }

       
    }
}
