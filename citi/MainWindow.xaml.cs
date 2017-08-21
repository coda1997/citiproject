using JumpKick.HttpLib;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window

    {
        // private string imagePath = "./avatar.png";
        public MainWindow()
        {
            InitializeComponent();
            //imageView.Source = new BitmapImage(new Uri(imagePath,UriKind.RelativeOrAbsolute));
            //if (imageView.Source == null)
            //{
            //    Console.WriteLine("not blend.");
            //}
            //else {
            //    Console.WriteLine(imageView.Source);
            //}

        }
        private String username;
        private String password;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            username = username_text.Text;
            password = password_text.Password;
            if (login(username, password) == 0) {
                Window main = new Main();
                this.Hide();
                main.Show();
            }


        }

        private int login(string username,string password){
            Http.Get("http://www.baidu.com").OnSuccess(result => { Console.WriteLine("connnet succeed" + username+" "+password); }).Go();
            return 0;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            username_text.Clear();
            password_text.Clear();
        }
    }
}
