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
        private AddAnaDetail detailPage1 ;
        private AddAnaDetail02 detailPage2 ;

        public AddAna()
        {
            InitializeComponent();
            detailPage1 = new AddAnaDetail(this);
            detailPage2 = new AddAnaDetail02(this);
            



        }
        private MyEntity entity = new MyEntity();
        private bool flag1 = false, flag2 = false;

        private Page ana01;
        private Page ana02;
        private Page ana03;
        private Page ana04;
        private string name = null;




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag1)
                return;
            flag1 = true;
            if (detailPage1 == null)
                return;
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
            if (detailPage2 == null)
                return;
           
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
            entity.asset_standard = asset_standard.Text;
            entity.cash = cash.Text;
            entity.currency_market_tool = currency_market_tool.Text;
            entity.asset = asset.Text;
            entity.cost_deposit = cost_deposit.Text;
            entity.cost_finance = cost_finance.Text;

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

            entity.trust_rate = detailPage1.Trust_rate;
            entity.trust_debt = detailPage1.Trust_debt;
            entity.debt_foundation = detailPage1.Debt_foundation;
            entity.trust_debtRights = detailPage1.Trust_debtRights;
            entity.trust_stock = detailPage1.Trust_stock;
            entity.trust_transfer = detailPage1.Trust_transfer;
            entity.receive = detailPage1.Receive;
            entity.self_debtRights = detailPage1.Self_debtRights;
            entity.other = detailPage1.Other;
            entity.credit = detailPage1.Credit;
            entity.bill = detailPage1.Bill;
            entity.national_debt = detailPage2.National_debt;
            entity.enterprise_debt = detailPage2.Enterprise_debt;
            //MessageBox.Show(entity.ToString());
            entity.bond = (string)bondLabel.Content;
            entity.nonStandardAssets = (string)nonStandardAssetsLabel.Content;
            entity.bank_deposit_rate = bank_deposit_rate.Text;
            entity.financial_products = financial_products.Text;

            if (entity.IsAllSetValue())
            {
                Console.WriteLine("null safe");
                return;
            }
            

            name = DateTime.Now.ToLocalTime().ToString("hh:mm:ss");
            string date = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd");
            string sql = "INSERT INTO record (name,date,probability,comment,asset_standard,national_debt,enterprise_debt,trust_rate,trust_debt,debt_foundation,trust_debtRights,trust_stock,trust_transfer,receive,self_debtRights,bill,credit,other,cash,currency_market_tool,asset,cost_deposit," +
                "cost_finance,bank_deposit_rate,financial_products) VALUES('新建分析-" + name+"','"+date+"',"+"'-'"+","+"'--'"+",'"+
                entity.asset_standard+"','"+
                entity.national_debt+"','"+
                entity.enterprise_debt+"','"+
                entity.trust_rate+"','"+
                entity.trust_debt+"','"+
                entity.debt_foundation+"','"+
                entity.trust_debtRights+"','"+
                entity.trust_stock+"','"+
                entity.trust_transfer+"','"+
                entity.receive+"','"+
                entity.self_debtRights+"','"+
                entity.bill+"','"+
                entity.credit+"','"+
                entity.other+"','"+
                entity.cash+"','"+
                entity.currency_market_tool+"','"+
                entity.asset+"','"+
                entity.cost_deposit+"','"+
                entity.cost_finance+"','"+
                entity.bank_deposit_rate+ "','" +
                entity.financial_products+"');";

            SqliteHelper.ExecuteSQLWithoutResult(sql);
            ana01 = new AnaResult01(this);
            ana02 = new AnaResult02(this);
            ana03 = new AnaResult03(this, "新建分析-" + name);
            ana04 = new AnaResult04(this);

            this.NavigationService.Navigate(ana01);

        }


        public MyEntity getEntity()
        {
            return entity;
        }
        public Page getPage01()
        {
            if (ana01 == null)
            {
                ana01 = new AnaResult01(this);
            }
            return ana01;
        }
        public Page getPage02()
        {
            if (ana02 == null)
            {
                ana02 = new AnaResult02(this);
            }
            return ana02;
        }
        public Page getPage03()
        {
            if (ana03 == null)
            {
                if(name!=null)
                    ana03 = new AnaResult03(this,"新建分析-" + name);
                
            }
            return ana03;
        }

        private void asset_standard_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_time_TextChanged(sender,e);
        }

        public Page getPage04()
        {
            if (ana04 == null)
            {
                ana04 = new AnaResult04(this);
            }
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

        public void txt_time_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkType(sender, e);
            valueChangeUpdate();
        }
        private void checkType(object sender, TextChangedEventArgs e) {

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
        public void valueChangeUpdate(  ) {
            double trust_rate =  toDouble(detailPage1.Trust_rate);
            double trust_debt = toDouble(detailPage1.Trust_debt);
            double debt_foundation = toDouble(detailPage1.Debt_foundation);
            double trust_debtRights = toDouble(detailPage1.Trust_debtRights);
            double trust_stock = toDouble(detailPage1.Trust_stock);
            double trust_transfer = toDouble(detailPage1.Trust_transfer);
            double receive = toDouble(detailPage1.Receive);
            double self_debtRights = toDouble(detailPage1.Self_debtRights);
            double other = toDouble(detailPage1.Other);
            double credit = toDouble(detailPage1.Credit);
            double bill = toDouble(detailPage1.Bill);

            double res1 = trust_rate + trust_debt + debt_foundation + trust_debtRights + trust_stock 
                + trust_transfer + receive + self_debtRights + other + credit + bill;
            nonStandardAssetsLabel.Content = String.Format("{0:F}", res1);

            double national_debt = toDouble(detailPage2.National_debt);
            double enterprise_debt = toDouble(detailPage2.Enterprise_debt);
            double res2= national_debt + enterprise_debt;
            bondLabel.Content = String.Format("{0:F}", res2);

            double cashDouble = toDouble(cash.Text);
            double currentMarket = toDouble(currency_market_tool.Text);
            double assetsDouble = toDouble(asset.Text);
            double res3 = cashDouble + currentMarket + assetsDouble;
            shadowBank.Content = String.Format("{0:F}", res1+res2+res3);

            double assetsBank = toDouble(asset_standard.Text);

            wholeAssets.Content = String.Format("{0:F}", res1 + res2 + res3 + assetsBank);



        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            //main
            asset_standard.Text = "0";
            cash.Text = "0";
            currency_market_tool.Text = "0";
            asset.Text = "0";
            cost_deposit.Text = "0";
            cost_finance.Text = "0";
            bank_deposit_rate.Text = "0";
            financial_products.Text = "0";
            //detail page 1
            detailPage1.Trust_rate = "0";
            detailPage1.Trust_debt = "0";
            detailPage1.Debt_foundation = "0";
            detailPage1.Trust_debtRights = "0";
            detailPage1.Trust_stock = "0";
            detailPage1.Trust_transfer = "0";
            detailPage1.Receive = "0";
            detailPage1.Self_debtRights = "0";
            detailPage1.Bill = "0";
            detailPage1.Credit = "0";
            detailPage1.Other = "0";
            //detail page 2
            detailPage2.National_debt = "0";
            detailPage2.Enterprise_debt = "0";
        }

        private double toDouble(string value)
        {
            if (value.Equals(""))
                return 0;
            else
                return Convert.ToDouble(value);
        }
       
    }
}
