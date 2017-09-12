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
        public AnaResult02()
        {
            InitializeComponent();
        }
        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
            image1.Visibility = Visibility.Hidden;
            image2.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;

        }

        private void image2_MouseLeave(object sender, MouseEventArgs e)
        {
            image1.Visibility = Visibility.Visible;
            image2.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnaResult01());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnaResult02());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnaResult03());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AnaResult04());
        }
    }

    public class PieChartData
    {
        private PlotModel modelP1;
        public PieChartData()
        {
            modelP1 = new PlotModel { Title = "输入数据分析" };

            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            modelP1.Series.Add(seriesP1);

        }

        public PlotModel Model1
        {
            get { return modelP1; }
            set { modelP1 = value; }
        }
    }

}
