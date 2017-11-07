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
using OxyPlot;
using OxyPlot.Series;

namespace citi.MyPage
{
    /// <summary>
    /// AnaResult02.xaml 的交互逻辑
    /// </summary>
    public partial class AnaResult02 : Page
    {
        public AnaResult02(AddAna pageArg)
        {
            InitializeComponent();
            dataPage = pageArg;
            plot1.Model = getModel();
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

        private PlotModel getModel()
        {
            MyEntity entity = dataPage.getEntity();

            string asset_standard = entity.asset_standard;      //标准资产
            string bond = entity.bond;
            string nonStandardAssets = entity.nonStandardAssets;
            string cash = entity.cash;               //现金及银行存款
            string currency_market_tool = entity.currency_market_tool;//货币市场工具
            string asset = entity.asset;            //权益类资产
            string other = entity.other;

            PlotModel modelP1 = new PlotModel { Title = " " };
            dynamic seriesP1 = new PieSeries { StrokeThickness = 1, AngleSpan = 360, StartAngle = 0 };
            seriesP1.Slices.Add(new PieSlice("", Convert.ToDouble(asset_standard)) { Fill = OxyColor.Parse("#5a95be") });
            seriesP1.Slices.Add(new PieSlice("", Convert.ToDouble(bond)) { Fill = OxyColor.Parse("#b4bbd5") });
            seriesP1.Slices.Add(new PieSlice("", Convert.ToDouble(nonStandardAssets)) { Fill = OxyColor.Parse("#9DA5BE") });
            seriesP1.Slices.Add(new PieSlice("", Convert.ToDouble(cash)) { Fill = OxyColor.Parse("#8691A7") });
            seriesP1.Slices.Add(new PieSlice("", Convert.ToDouble(currency_market_tool)) { Fill = OxyColor.Parse("#717D90") });
            seriesP1.Slices.Add(new PieSlice("", Convert.ToDouble(asset)) { Fill = OxyColor.Parse("#5A6777") });
            seriesP1.Slices.Add(new PieSlice("", Convert.ToDouble(other)) { Fill = OxyColor.Parse("#d5d5d5") });
            
            modelP1.Series.Add(seriesP1);

            return modelP1;
        }
    }

}
