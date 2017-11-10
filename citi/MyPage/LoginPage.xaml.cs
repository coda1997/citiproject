using citi.MyWindow;
using JumpKick.HttpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Page
    {
        private Window currentWindow;
        public Window CurrentWindow { get { return currentWindow; } set { currentWindow=value; } }

        public LoginPage()
        {
            InitializeComponent();

        }

        private RegisterPage registerPage;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = username_text.Text;
            string pwd = password_text.Password;
            if (!emailIsValid(email))
            {
                tipsText.Content = "email格式错误，请重试";
                MyLog.FailLog("The email is not valid");
            }
            Http.Post(Constant.LoginUrl).Form(new { email = email, password = pwd, remembered = false }).OnSuccess((WebHeaderCollection header, string resutlt) =>
               {

                   new Thread(() =>
                   {
                       this.Dispatcher.Invoke(new Action(() =>
                       {
                           Window mainWindow = new Main();
                           mainWindow.Show();
                           if (currentWindow != null)
                           {
                               currentWindow.Hide();
                           }
                       }));
                   }).Start();

               }).OnFail(exception =>
               {
                   new Thread(() =>
                   {
                       this.Dispatcher.Invoke(new Action(() =>
                       {
                           tipsText.Content = "网络或密码错误，请重试";

                       }));
                   }).Start();
               }).Go();
            //Window mainWindow = new Main();
            //mainWindow.Show();
            //if (currentWindow != null)
            //{
            //    currentWindow.Hide();
            //}


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (registerPage == null)
                registerPage = new RegisterPage();
            currentWindow.Content = registerPage;
            registerPage.MyWindow = currentWindow;
            registerPage.PrePage = this;
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
