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
            if (num == 1 || entity1 == null||entity2==null)
                return;

            MyEntity entity_1 = entity1;
            MyEntity entity_2 = entity2;

            this.NavigationService.Navigate(new ComparePage(entity_1, entity_2));



        }

        private int num = 0;
        private MyEntity entity1;
        private MyEntity entity2;
        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRow dataRow;
            num =(num+1)%2;
            if (num == 1)
            {
                
                chooseText.Content = "选中项目 1/2";
                dataRow = drc[(currentPage - 1) * 15 + myListView.SelectedIndex];
                entity1 = new MyEntity();
                entity1.Asset_standard = dataRow[5]+"";
                entity1.National_debt = dataRow[6]+"";
                entity1.Enterprise_debt = dataRow[7]+"";
                entity1.Trust_rate = dataRow[8]+"";
                entity1.Trust_debt = dataRow[9]+"";
                entity1.Debt_foundation = dataRow[10]+"";
                entity1.Trust_debtRights = dataRow[11]+"";
                entity1.Trust_stock = dataRow[12]+"";
                entity1.Trust_transfer = dataRow[13]+"";
                entity1.Receive = dataRow[14]+"";
                entity1.Self_debtRights = dataRow[15]+"";
                entity1.Bill = dataRow[16]+"";
                entity1.Credit = dataRow[17]+"";
                entity1.Other = dataRow[18]+"";
                entity1.Cash = dataRow[19]+"";
                entity1.Currency_market_tool = dataRow[20]+"";
                entity1.Asset = dataRow[21]+"";
                entity1.Cost_deposit = dataRow[22]+"";
                entity1.Cost_finance = dataRow[23]+"";
            }
            else
            {
                dataRow = drc[(currentPage - 1) * 15 + myListView.SelectedIndex];

                chooseText.Content = "选中项目 2/2";
                entity2 = new MyEntity();

                entity2.Asset_standard = dataRow[5]+"";
                entity2.National_debt = dataRow[6]+"";
                entity2.Enterprise_debt = dataRow[7]+"";
                entity2.Trust_rate = dataRow[8]+"";
                entity2.Trust_debt = dataRow[9]+"";
                entity2.Debt_foundation = dataRow[10]+"";
                entity2.Trust_debtRights = dataRow[11]+"";
                entity2.Trust_stock = dataRow[12]+"";
                entity2.Trust_transfer = dataRow[13]+"";
                entity2.Receive = dataRow[14]+"";
                entity2.Self_debtRights = dataRow[15]+"";
                entity2.Bill = dataRow[16]+"";
                entity2.Credit = dataRow[17]+"";
                entity2.Other = dataRow[18]+"";
                entity2.Cash = dataRow[19]+"";
                entity2.Currency_market_tool = dataRow[20]+"";
                entity2.Asset = dataRow[21]+"";
                entity2.Cost_deposit = dataRow[22]+"";
                entity2.Cost_finance = dataRow[23]+"";
            }
            
            MyLog.FailLog(myListView.SelectedIndex+"");
        }

        private HistoryEntry GetHistoryEntry(object sender)
        {
          
            return null;
        }
    }
}
