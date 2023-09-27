﻿using System;
using System.Windows;
using System.Windows.Threading;

namespace D_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 時刻設定用タイマー
        /// </summary>
        private readonly DispatcherTimer _timer = new();
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //タイマー初期化
            InitializeTime();
            _timer.Start();
        }

        /// <summary>
        /// タイマー初期化
        /// </summary>
        private void InitializeTime()
        {
            // イベント発生間隔の設定
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            // イベント登録
            _timer.Tick += (_, _) =>
            {
                // 現在時刻を設定
                TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            };
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
