using System;
using System.Collections.Generic;
using System.Data;
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
    /// HistoryPage.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryPage : Page
    {
        private List<HistoryEntry> list = new List<HistoryEntry>();

        public HistoryPage()
        {
            InitializeComponent();
            InitView();
            
        }

        private void InitView()
        {
            DataSet ds = SqliteHelper.ExecuteDataset("SELECT * FROM record;", null);

            //list.Add(new HistoryEntry("col1","col2","col3","col4"));
            var rows = ds.Tables[0].Rows;
            foreach (DataRow row in rows)
                list.Add(new HistoryEntry(row[1] + "", row[2] + "", row[3] + "", row[4] + ""));
            myListView.ItemsSource = list;
        }
    }
}
