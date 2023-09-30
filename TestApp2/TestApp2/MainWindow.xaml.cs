using System;
using System.Collections.Generic;
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

namespace TestApp2
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn)
            {
                return;
            }

            switch (btn.Content.ToString())
            {
                case "〇〇の確認":
                    MessageBox.Show("〇〇です");
                    break;
                case "△△の確認":
                    MessageBox.Show("△△です");
                    break;
                default:
                    MessageBox.Show("その他のボタンが押されました");
                    break;
            }
        }
    }
}
