using JumpKick.HttpLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Newtonsoft.Json;
using citi;
using System.IO;

namespace citi.MyPage
{
    /// <summary>
    /// AnaResult03.xaml 的交互逻辑
    /// </summary>
    public partial class AnaResult03 : Page
    {
        String name;
        public AnaResult03(AddAna pageArg,String name)
        {
            this.name = name;
            InitializeComponent();
            dataPage = pageArg;
            initChart();
        }

        private void initChart()
        {
            webBrower.NavigateToString(new StreamReader("./demo.html").ReadToEnd());
        }

        private void updataHistory(String probability)
        {
            String sql = "update record set probability= '" + probability + "' where name = '"+name+"';";
            SqliteHelper.ExecuteSQLWithoutResult(sql);
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
            PlotModel modelP1 = new PlotModel { Title = " " };
            dynamic seriesP1 = new FunctionSeries() { Color = OxyColor.Parse("#5a95be") };
            dynamic seriesP2 = new LineSeries() { Color = OxyColor.Parse("#e9445f") };

            //dynamic requestParam = new
            //{
            //    email = email,
            //};


            string response = "";

            #region 错误示范
            Http.Get("http://39.108.217.238:8080/history/?format=json&year=2016").OnSuccess(result =>
            {
                response = result;
                JsonOverview data = JsonConvert.DeserializeObject<JsonOverview>(response);
                int sum = 500;
                for (int i = 0; i < sum; i++)
                {
                    seriesP1.Points.Add(new DataPoint(data.points[0][i], data.points[1][i]));
                }
                seriesP2.Points.Add(new DataPoint(data.cost, 0));
                seriesP2.Points.Add(new DataPoint(data.cost, 0.06));

                modelP1.Series.Add(seriesP1);
                modelP1.Series.Add(seriesP2);

                this.Dispatcher.Invoke(new Action(() =>
                {
                    String probability = (Convert.ToDouble(data.probability) * 100).ToString("f2") + "%";
                    label.Content = "违约概率：" + probability;
                    updataHistory(probability);
                }));

            }).OnFail(res => { Console.WriteLine("ana result03 fail" + res); }).Go();
            #endregion




            return modelP1;
        }
    }

}
