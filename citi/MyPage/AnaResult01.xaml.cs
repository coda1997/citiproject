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
    /// AnaResult01.xaml 的交互逻辑
    /// </summary>
    public partial class AnaResult01 : Page
    {
        public AnaResult01(AddAna pageArg)
        {
            InitializeComponent();
            dataPage = pageArg;
            MyEntity entity = dataPage.getEntity();
            label17.Content = entity.asset_standard;      //标准资产
            label18.Content = entity.bond;
            label19.Content = entity.nonStandardAssets;
            label20.Content = entity.cash;               //现金及银行存款
            label21.Content = entity.currency_market_tool;//货币市场工具
            label22.Content = entity.asset;            //权益类资产
            label23.Content = entity.other;
            label24.Content = entity.getAssetsTotal();
            label37.Content = entity.cost_deposit;     //定期存款
            label38.Content = entity.cost_finance;        //理财产品
            label39.Content = entity.getLoanTotal();
            label42.Content = Convert.ToDouble(entity.getAssetsTotal()) - Convert.ToDouble(entity.getLoanTotal());
            label43.Content = Convert.ToDouble(entity.getAssetsTotal()) - Convert.ToDouble(entity.getLoanTotal());
            label44.Content = entity.getTwoTotal();

        }

        private AddAna dataPage;

        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
            image1.Visibility = Visibility.Hidden;
            image2.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
            label46.Visibility = Visibility.Visible;
        }

        private void image2_MouseLeave(object sender, MouseEventArgs e)
        {
            image1.Visibility = Visibility.Visible;
            image2.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
            label46.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(dataPage.getPage01());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(dataPage.getPage02());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(dataPage.getPage03());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(dataPage.getPage04());
        }
    }
}
