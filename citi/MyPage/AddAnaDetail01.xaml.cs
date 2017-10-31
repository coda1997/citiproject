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
        private AddAna prePage;
        public AddAnaDetail(AddAna page)
        {
            InitializeComponent();
            prePage = page;
        }
        public string Trust_rate { get { return trust_rate.Text; } set{ trust_rate.Text = value; } }
        public string Trust_debt { get { return trust_debt.Text; } set { trust_debt.Text = value; } }
        public string Debt_foundation { get { return debt_foundation.Text; } set { debt_foundation.Text = value; } }
        public string Trust_debtRights { get { return trust_debtRights.Text; } set { trust_debtRights.Text = value; } }
        public string Trust_stock { get { return trust_stock.Text; } set { trust_stock.Text = value; } }
        public string Trust_transfer { get { return trust_transfer.Text; } set { trust_transfer.Text = value; } }
        public string Receive { get { return receive.Text; } set { receive.Text = value; } }
        public string Self_debtRights { get { return self_debtRights.Text; } set { self_debtRights.Text = value; } }
        public string Bill { get { return bill.Text; } set { bill.Text = value; } }
        public string Credit { get { return credit.Text; } set { credit.Text = value; } }
        public string Other { get { return other.Text; } set { other.Text = value; } }




        

        private void trust_rate_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void trust_debt_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void debt_foundation_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void trust_debtRights_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void trust_stock_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void trust_transfer_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void receive_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void self_debtRights_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void bill_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void credit_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }

        private void other_TextChanged(object sender, TextChangedEventArgs e)
        {
            prePage.txt_time_TextChanged(sender, e);
        }
    }



}
