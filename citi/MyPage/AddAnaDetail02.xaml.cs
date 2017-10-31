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
    /// AddAnaDetail02.xaml 的交互逻辑
    /// </summary>
    public partial class AddAnaDetail02 : Page
    {
        private AddAna prePage;
        public AddAnaDetail02(AddAna page)
        {
            InitializeComponent();
            prePage = page;
        }
        public string National_debt { get { return national_debt.Text; } set { national_debt.Text = "0"; }  }
        public string Enterprise_debt { get { return enterprise_debt.Text; } set { enterprise_debt.Text = "0"; } }

        private void national_debt_TextChanged(object sender, TextChangedEventArgs e)
        {
           prePage.txt_time_TextChanged(sender, e);
        }

        private void enterprise_debt_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }
       

    }
}
