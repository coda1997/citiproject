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
            ConstructHTML(Constant.OverViewUrl, dataPage.getEntity(), Constant.DeChart);
        }
        private void ConstructHTML( String url, MyEntity entity, String webSource)
        {
            string content = new StreamReader(webSource).ReadToEnd();
            Http.Post(url).Body(Constant.DataType,entity.ToForm()).OnSuccess(result =>
            {
                string res = processHTML(content, result);
                JsonOverview json = JsonConvert.DeserializeObject<JsonOverview>(result);
                updataHistory(json.probability+"");
                new Thread(() =>
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        webBroswer.NavigateToString(res);
                        proText.Content = "违约概率：" + json.probability + "%";

                    }));
                }).Start();

            }).OnFail(result =>
            {
                Console.WriteLine(":post chart failed" + result);
            }).Go();
        }
        private string processHTML(string content, string data)
        {
            int start = content.IndexOf('@');
            string l = content.Substring(0, start);
            string m = content.Substring(start + 1);
            string n = "var data = " + data;
            return l + n + m;
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

  
    }

}
