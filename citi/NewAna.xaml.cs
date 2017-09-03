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
using System.Windows.Shapes;

namespace citi
{
    /// <summary>
    /// NewAna.xaml 的交互逻辑
    /// </summary>
    public partial class NewAna : Window
    {
        public NewAna()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data1.Text = "";
            data2.Text = "";
            data3.Text = "";
            data4.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window anaData = new AnaData();
            this.Hide();
            anaData.Show();
        }
    }
}
