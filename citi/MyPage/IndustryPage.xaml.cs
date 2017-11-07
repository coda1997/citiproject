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
using citi.MyWindow;

namespace citi.MyPage
{
    /// <summary>
    /// IndustryPage.xaml 的交互逻辑
    /// </summary>
    public partial class IndustryPage : Page
    {
        public IndustryPage()
        {
            InitializeComponent();
        }

    

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window industry = new IndustryWindow(2014);
            industry.Show();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

            Window industry = new IndustryWindow(2015);
            industry.Show();
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Window industry = new IndustryWindow(2016);
            industry.Show();
        }
    }
}
