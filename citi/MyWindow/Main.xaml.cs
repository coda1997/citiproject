using citi.MyPage;
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

namespace citi.MyWindow
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            newAnaPage = new AddAna();
            mainFrame.Content = newAnaPage;

        }
        private Page newAnaPage;
        private Page historyPage;
        private Page industryPage;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (newAnaPage == null)
                newAnaPage = new AddAna();
            mainFrame.Content = newAnaPage;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (historyPage == null)
                historyPage = new HistoryPage();
            mainFrame.Content = historyPage;  
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (industryPage == null)
                industryPage = new IndustryPage();
            mainFrame.Content = industryPage;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
