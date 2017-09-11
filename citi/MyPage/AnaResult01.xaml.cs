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

namespace citi.MyPage
{
    /// <summary>
    /// AnaResult01.xaml 的交互逻辑
    /// </summary>
    public partial class AnaResult01 : Page
    {
        public AnaResult01()
        {
            InitializeComponent();
        }

        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
            image1.Visibility = Visibility.Hidden;
            image2.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;

        }

        private void image2_MouseLeave(object sender, MouseEventArgs e)
        {
            image1.Visibility = Visibility.Visible;
            image2.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnaResult01());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnaResult02());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnaResult03());
        }
    }
}
