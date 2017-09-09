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
    /// AddAnaDetail.xaml 的交互逻辑
    /// </summary>
    public partial class AddAnaDetail : Page
    {
        public AddAnaDetail()
        {
            InitializeComponent();
            
        }
        public string Trust_rate { get { return trust_debt.Text; } }
        public string Trust_debt { get { return trust_debt.Text; } }
        public string Debt_foundation { get { return debt_foundation.Text; } }
        public string Trust_debtRights { get { return trust_debt.Text; } }
        public string Trust_stock { get { return trust_stock.Text; } }
        public string Trust_transfer { get { return trust_transfer.Text; } }
        public string Receive { get { return receive.Text; } }
        public string Self_debtRights { get { return self_debtRights.Text; } }
        public string Bill { get { return bill.Text; } }
        public string Credit { get { return credit.Text; } }
        public string Other { get { return other.Text; } }





    }

}
