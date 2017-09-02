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
        private String testUrl = "http://127.0.0.1:8000/login";
        private String loginUrl = "http://www.baidu.com";
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            username = username_text.Text;
            password = password_text.Password;
            if (login(username, password) == 0)
            {
                Window main = new Main();
                this.Hide();
                main.Show();
            }
            else {
                MessageBox.Show("邮箱或密码输入不正确，请重新输入");
                password_text.Password = "";
            }


        }

        private int login(string username,string password){
            int state = 0;
            Http.Post(loginUrl).Form(new {email=username,password=password }).OnSuccess(result => { Console.WriteLine("connnet succeed" + username+" "+password); state = 1; }).OnFail (exception=>{ state = 0;Console.WriteLine(exception.Message); }).Go();
            return state;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            username_text.Clear();
            password_text.Clear();
            new RegisterWindow().Show();
           // this.Hide();
        }
        private bool emailIsValid(String email)
        {
            String regular = "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$";
            return Regex.IsMatch(email, regular);
        }
        private bool pwdIsValid(String pwd)
        {
            //add more regular
            return pwd.Length > 5 && pwd.Length < 21;
        }
    }
}
