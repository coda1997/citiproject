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
    /// HistoryPage.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryPage : Page
    {
        private List<HistoryEntry> list = new List<HistoryEntry>();

        public HistoryPage()
        {
            InitializeComponent();

            list.Add(new HistoryEntry("col1","col2","col3","col4"));
            myListView.ItemsSource = list;
            
        }
    }
}
