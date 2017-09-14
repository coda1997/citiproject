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

namespace citi.MyPage
{
    /// <summary>
    /// AnaResult03.xaml 的交互逻辑
    /// </summary>
    public partial class AnaResult03 : Page
    {
        public AnaResult03(AddAna pageArg)
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
            PlotModel modelP1 = new PlotModel { Title = " " };
            dynamic seriesP1 = new FunctionSeries() { Color = OxyColor.Parse("#5a95be") };
            dynamic seriesP2 = new LineSeries() { Color = OxyColor.Parse("#e9445f") } ;

            //dynamic requestParam = new
            //{
            //    email = email,
            //};

            //Http.Post(Constant.OverViewUrl).Form(new { email = email, password = pwd, remembered = false }).OnSuccess((WebHeaderCollection header, string resutlt) =>
            //   {
            //       //MyLog.FailLog(header.ToString());
            //       //MyLog.FailLog(Constant.Cookie);
            //       new Thread(() =>
            //       {
            //           this.Dispatcher.Invoke(new Action(() =>
            //           {
            //               Window mainWindow = new Main();
            //               mainWindow.Show();
            //               if (currentWindow != null)
            //               {
            //                   currentWindow.Hide();
            //               }
            //           }));
            //       }).Start();

            //   }).OnFail(exception => MyLog.FailLog(exception.Message)).Go();

            string response = "";
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
                    label.Content = "违约概率：" + (Convert.ToDouble(data.probability) * 100).ToString("f2") + "%";
                }));

            }).Go();

            return modelP1;
        }
    }

}
