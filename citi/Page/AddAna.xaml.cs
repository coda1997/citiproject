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

namespace citi
{
    /// <summary>
    /// AddAna.xaml 的交互逻辑
    /// </summary>
    public partial class AddAna : Page
    {
        public AddAna()
        {
            InitializeComponent();
        }
        private Page detailPage1;
        private Page detailPage2;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(detailPage1==null)
            detailPage1    = new AddAnaDetail();
            detailFrame.Content = detailPage1;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(detailPage2==null)
            detailPage2 = new AddAnaDetail02();
            detailFrame.Content = detailPage2;
        }
    }
}
