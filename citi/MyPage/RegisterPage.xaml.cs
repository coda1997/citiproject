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
    /// RegisterPage.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        public Page PrePage { set; get; }
        public Window MyWindow { set; get; }

       
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String email = username_text.Text;
            String pwd = password_text.Password;
            String pwdConfirm = password_text_Copy.Password;
            if (!pwd.Equals(pwdConfirm))
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入");
                return;
            }
            if (emailIsValid(email) && pwdIsValid(pwd))
                Http.Post(Constant.RegisterUrl).Form(new { email = email, password = pwd, password_confirm = pwdConfirm }).OnSuccess(result => {
                    MyLog.FailLog("register succeed");
                    if (PrePage == null||MyWindow==null) {
                        MyLog.FailLog("the prepage is null");
                        return;
                    }
                    else
                    {
                        MyWindow.Content = PrePage;
                    }

                }).OnFail(result => { MessageBox.Show("register failed"); }).Go();
            else
            {
                MyLog.FailLog("email or password is not valid");
                MessageBox.Show("email or password is not valid");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
