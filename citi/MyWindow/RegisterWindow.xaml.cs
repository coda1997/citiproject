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
using System.Windows.Shapes;

namespace citi.MyWindow
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private readonly String registerUrl = "http://127.0.0.1:8000/register";


        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            String email = emailText.Text;
            String pwd = passwordText.Password;
            String pwdConfirm = passwordConfirmText.Password;
            if (!pwd.Equals(pwdConfirm)) {
                MessageBox.Show("两次输入的密码不一致，请重新输入");
                return;
            }

            if (emailIsValid(email) && pwdIsValid(pwd))
                Http.Post(registerUrl).Form(new { email = email, password = pwd }).OnSuccess(result => { Console.WriteLine("register succeed"); }).OnFail(result => { MessageBox.Show("register failed"); }).Go();
            else {
                MyLog.FailLog("email or password is not valid");
                MessageBox.Show("email or password is not valid");
            }
                
        }

        private bool emailIsValid(String email) {
            String regular = "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$";
            return Regex.IsMatch(email, regular);
        }
        private bool pwdIsValid(String pwd) {
            //add more regular
            return pwd.Length > 5 && pwd.Length < 21;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

        }
    }
}
