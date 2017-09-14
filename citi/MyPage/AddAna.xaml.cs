﻿using System;
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
    /// AddAna.xaml 的交互逻辑
    /// </summary>
    public partial class AddAna : Page
    {
        public AddAna()
        {
            InitializeComponent();
            
      

            
            
        }
        private AddAnaDetail detailPage1;
        private AddAnaDetail02 detailPage2;
        private MyEntity entity = new MyEntity();
        private bool flag1 = false, flag2 = false;

        private Page ana01;
        private Page ana02;
        private Page ana03;
        private Page ana04;




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag1)
                return;
            flag1 = true;
            if(detailPage1==null)
            detailPage1    = new AddAnaDetail();
            detailFrame.Content = detailPage1;
            if (flag2 == true)
            {
                flag2 = false;
                extend1.Content = "+展开";
                extend2.Content = "-折叠";
            }
            else
            {
                //flag2 = true;
                extend2.Content = "-折叠";
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (flag2)
                return;
            flag2 = true;
            if (detailPage2==null)
            detailPage2 = new AddAnaDetail02();
            detailFrame.Content = detailPage2;
            if (flag1 == true)
            {
                flag1 = false;
                extend2.Content = "+展开";
                extend1.Content = "-折叠";
            }
            else
            {
                //flag1 = true;
                extend1.Content = "-折叠";
            }

        }

        private void startAnaBtn_Click(object sender, RoutedEventArgs e)
        {
            entity.Asset_standard = asset_standard.Text;
            entity.Cash = cash.Text;
            entity.Currency_market_tool = currency_market_tool.Text;
            entity.Asset = asset.Text;
            entity.Cost_deposit = cost_deposit.Text;
            entity.Cost_finance = cost_finance.Text;

            if (detailPage1 == null)
            {
                MessageBox.Show("其他非标准化债权类投资尚未填写");
                return;
            }
            if (detailPage2 == null)
            {
                MessageBox.Show("债权尚未填写！");
                return;
            }

            entity.Trust_rate = detailPage1.Trust_rate;
            entity.Trust_debt = detailPage1.Trust_debt;
            entity.Debt_foundation = detailPage1.Debt_foundation;
            entity.Trust_debtRights = detailPage1.Trust_debtRights;
            entity.Trust_stock = detailPage1.Trust_stock;
            entity.Trust_transfer = detailPage1.Trust_transfer;
            entity.Receive = detailPage1.Receive;
            entity.Self_debtRights = detailPage1.Self_debtRights;
            entity.Other = detailPage1.Other;
            entity.Credit = detailPage1.Credit;
            entity.Bill = detailPage1.Bill;
            entity.National_debt = detailPage2.National_debt;
            entity.Enterprise_debt = detailPage2.Enterprise_debt;
            //MessageBox.Show(entity.ToString());


            ana01 = new AnaResult01(this);
            ana02 = new AnaResult02(this);
            ana03 = new AnaResult03(this);
            ana04 = new AnaResult04(this);

            this.NavigationService.Navigate(ana01);

        }


        public MyEntity getEntity()
        {
            return entity;
        }
        public Page getPage01()
        {
            return ana01;
        }
        public Page getPage02()
        {
            return ana02;
        }
        public Page getPage03()
        {
            return ana03;
        }

        private void asset_standard_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender,e);
        }

        public Page getPage04()
        {
            return ana04;
        }

        private void cash_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);

        }

        private void currency_market_tool_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);

        }

        private void asset_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);

        }

        private void cost_deposit_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);

        }

        private void cost_finance_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);

        }

        private void bank_deposit_rate_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender, e);

        }

        private void financial_products_TextChanged(object sender, TextChangedEventArgs e)
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
