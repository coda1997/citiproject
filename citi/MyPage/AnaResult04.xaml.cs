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
using OxyPlot;
using OxyPlot.Series;

namespace citi.MyPage
{
    /// <summary>
    /// AnaResult04.xaml 的交互逻辑
    /// </summary>
    public partial class AnaResult04 : Page
    {
        public AnaResult04(AddAna pageArg)
        {
            InitializeComponent();
            dataPage = pageArg;
            plot1.Model = getModel1();
            plot2.Model = getModel2();
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

        private PlotModel getModel1()
        {
            MyEntity entity = dataPage.getEntity();
            PlotModel modelP1 = new PlotModel { Title = "资产价值分布曲线" };

            dynamic seriesP1 = new FunctionSeries();

            seriesP1.Points.Add(new DataPoint(1, 1));
            seriesP1.Points.Add(new DataPoint(2, 2));
            seriesP1.Points.Add(new DataPoint(3, 2));
            seriesP1.Points.Add(new DataPoint(2, 1));

            modelP1.Series.Add(seriesP1);

            return modelP1;
        }

        private PlotModel getModel2()
        {
            MyEntity entity = dataPage.getEntity();
            PlotModel modelP2 = new PlotModel { Title = "偏效应图" };

            dynamic seriesP2 = new FunctionSeries();

            seriesP2.Points.Add(new DataPoint(1, 1));
            seriesP2.Points.Add(new DataPoint(2, 2));
            seriesP2.Points.Add(new DataPoint(3, 2));
            seriesP2.Points.Add(new DataPoint(2, 1));

            modelP2.Series.Add(seriesP2);

            return modelP2;
        }

    }

}
