using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAlarm
{
    class MsgBox
    {
        public static void ShowErr(string msg)
        {
            MessageBox.Show(msg, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// 情報メッセージ表示
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "情報", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    
}
