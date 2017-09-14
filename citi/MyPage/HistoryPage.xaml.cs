using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //private List<HistoryEntry> list = new List<HistoryEntry>();
        private ObservableCollection<HistoryEntry> list = new ObservableCollection<HistoryEntry>();
        private int count = 0;
        private DataRowCollection drc;
        public HistoryPage()
        {
            InitializeComponent();
            InitView();
            
        }

        private void InitView()
        {
            DataSet ds = SqliteHelper.ExecuteDataset("SELECT * FROM record ORDER BY date desc;", null);
            //for(int i = 0; i < 20; i++)
            //{
            //list.Add(new HistoryEntry("col1", "col2", "col3", "col4"));

            //}
            drc = ds.Tables[0].Rows;
            foreach (DataRow row in drc)
            {
                if (count > 15 )
                    break;
                list.Add(new HistoryEntry(row[1] + "", row[2] + "", row[3] + "", row[4] + ""));
                count++;
            }
            myListView.ItemsSource = list;
        }

        private int currentPage = 1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage == 1)
                return;
            ShowDateFromTo((currentPage - 2) * 15, (currentPage - 1) * 15);
            currentPage --;
            MyLog.FailLog("pre btn clicked");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentPage == 4)
                return;
            ShowDateFromTo(currentPage * 15, (currentPage + 1) * 15);
            currentPage++;
            MyLog.FailLog("next btn clicked");

        }

        private void ShowDateFromTo(int start,int end)
        {
            if (start < 0 || end < 1)
                return;
            list.Clear();
            MyLog.FailLog("the current page is "+currentPage);
            for(int i = start; i< end; i++)
            {
                if (i >= drc.Count)
                    break;
                DataRow row = drc[i];
                list.Add(new HistoryEntry(row[1] + "", row[2] + "", row[3] + "", row[4] + ""));
            }
            myListView.ItemsSource = list;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (num == 1 || history1 == null||history2==null)
                return;

        }

        private int num = 0;
        private HistoryEntry history1;
        private HistoryEntry history2;
        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            num =(num+1)%2;
            if (num == 1)
            {
                chooseText.Content = "选中项目 1/2";
                
            }
            else
            {
                chooseText.Content = "选中项目 2/2";
            }
            MyLog.FailLog(sender.ToString());
        }

        private HistoryEntry GetHistoryEntry(object sender)
        {
            return null; 
        }
    }
}
