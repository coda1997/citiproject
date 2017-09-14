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




        private void txt_time_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);
            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
        }

        private void trust_rate_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void trust_debt_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void debt_foundation_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void trust_debtRights_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void trust_stock_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void trust_transfer_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void receive_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void self_debtRights_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void bill_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void credit_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void other_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }
    }



}
