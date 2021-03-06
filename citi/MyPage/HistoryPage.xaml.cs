﻿using System;
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
        public void UpdataData()
        {
            InitView();
        }
        private void InitView()
        {
            count = 0;
            list.Clear();
            DataSet ds = SqliteHelper.ExecuteDataset("SELECT * FROM record ORDER BY date DESC,name desc", null);
       
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
            if (drc.Count == 0)
                return;
            DataRow dataRow;
            num =(num+1)%2;
            int index = (currentPage - 1) * 15 + myListView.SelectedIndex;
            if (index < 0 || index > drc.Count)
                return;
            if (num == 1)
            {
                
                chooseText.Content = "选中项目 1/2";
                dataRow = drc[index];
                entity1 = new MyEntity();
                entity1.asset_standard = dataRow[5]+"";
                entity1.national_debt = dataRow[6]+"";
                entity1.enterprise_debt = dataRow[7]+"";
                entity1.trust_rate = dataRow[8]+"";
                entity1.trust_debt = dataRow[9]+"";
                entity1.debt_foundation = dataRow[10]+"";
                entity1.trust_debtRights = dataRow[11]+"";
                entity1.trust_stock = dataRow[12]+"";
                entity1.trust_transfer = dataRow[13]+"";
                entity1.receive = dataRow[14]+"";
                entity1.self_debtRights = dataRow[15]+"";
                entity1.bill = dataRow[16]+"";
                entity1.credit = dataRow[17]+"";
                entity1.other = dataRow[18]+"";
                entity1.cash = dataRow[19]+"";
                entity1.currency_market_tool = dataRow[20]+"";
                entity1.asset = dataRow[21]+"";
                entity1.cost_deposit = dataRow[22]+"";
                entity1.cost_finance = dataRow[23]+"";
                entity1.bank_deposit_rate = dataRow[24] + "";
                entity1.financial_products = dataRow[25] + "";
                entity1.bond = toDouble(entity1.national_debt) + toDouble(entity1.enterprise_debt) + "";
                entity1.nonStandardAssets = toDouble(entity1.trust_rate) + toDouble(entity1.trust_debt) +
                    toDouble(entity1.debt_foundation) + toDouble(entity1.trust_debtRights) +
                    toDouble(entity1.trust_stock) + toDouble(entity1.trust_transfer) + toDouble(entity1.receive) +
                    toDouble(entity1.self_debtRights) + toDouble(entity1.other) + toDouble(entity1.credit) + toDouble(entity1.bill) + "";
            }
            else
            {
                dataRow = drc[index];

                chooseText.Content = "选中项目 2/2";
                entity2 = new MyEntity();

                entity2.asset_standard = dataRow[5]+"";
                entity2.national_debt = dataRow[6]+"";
                entity2.enterprise_debt = dataRow[7]+"";
                entity2.trust_rate = dataRow[8]+"";
                entity2.trust_debt = dataRow[9]+"";
                entity2.debt_foundation = dataRow[10]+"";
                entity2.trust_debtRights = dataRow[11]+"";
                entity2.trust_stock = dataRow[12]+"";
                entity2.trust_transfer = dataRow[13]+"";
                entity2.receive = dataRow[14]+"";
                entity2.self_debtRights = dataRow[15]+"";
                entity2.bill = dataRow[16]+"";
                entity2.credit = dataRow[17]+"";
                entity2.other = dataRow[18]+"";
                entity2.cash = dataRow[19]+"";
                entity2.currency_market_tool = dataRow[20]+"";
                entity2.asset = dataRow[21]+"";
                entity2.cost_deposit = dataRow[22]+"";
                entity2.cost_finance = dataRow[23]+"";
                entity2.bank_deposit_rate = dataRow[24] + "";
                entity2.financial_products = dataRow[25] + "";
                entity2.bond = toDouble( entity2.national_debt) +toDouble( entity2.enterprise_debt)+"";
                entity2.nonStandardAssets = toDouble(entity2.trust_rate) + toDouble(entity2.trust_debt) +
                    toDouble(entity2.debt_foundation) + toDouble(entity2.trust_debtRights) +
                    toDouble(entity2.trust_stock) + toDouble(entity2.trust_transfer) + toDouble(entity2.receive) +
                    toDouble(entity2.self_debtRights) + toDouble(entity2.other) + toDouble(entity2.credit) + toDouble(entity2.bill)+"";
            }
            
            MyLog.FailLog(myListView.SelectedIndex+"");
        }
        private double toDouble(string value)
        {
            if (value.Equals(""))
                return 0;
            else
                return Convert.ToDouble(value);
        }
        private HistoryEntry GetHistoryEntry(object sender)
        {
          
            return null;
        }
    }
}
