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
        public AddAnaDetail02()
        {
            InitializeComponent();
        }
        public string National_debt { get { return national_debt.Text; }  }
        public string Enterprise_debt { get { return enterprise_debt.Text; } }

        private void national_debt_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }

        private void enterprise_debt_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);
        }
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

    }
}
