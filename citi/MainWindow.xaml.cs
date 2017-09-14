using JumpKick.HttpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data.SQLite;
using System.Data;
using citi.MyPage;

namespace citi
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window

    {
        private LoginPage loginPage;
        private Page RegisterPage;

        public MainWindow()
        {
            InitializeComponent();
      
            loginPage = new LoginPage();
            loginFrame.Content = loginPage;
            loginPage.CurrentWindow = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Constant.MinWindow();
        }

        private void loginFrame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
