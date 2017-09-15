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
using System.Net;
using OxyPlot;
using OxyPlot.Series;
using JumpKick.HttpLib;
using Newtonsoft.Json;
using System.Threading;
using System.IO;

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
            item = 0;
            jData = getData();
            plot1.Model = getModel1();
            plot2.Model = getModel2();

        }

        private AddAna dataPage;
        private int item;
        JsonPartial jData;

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
            PlotModel modelP1 = new PlotModel { Title = " " };
            dynamic seriesP1 = new FunctionSeries() { Color = OxyColor.Parse("#5a95be") };

            int sum = 500;
            for (int i = 0; i < sum; i++)
            {
                seriesP1.Points.Add(new DataPoint(jData.assets[0][i], jData.assets[1][i]));
            }
            modelP1.Series.Add(seriesP1);

            return modelP1;
        }

        private PlotModel getModel2()
        {

            PlotModel modelP1 = new PlotModel { Title = " " };
            dynamic seriesP1 = new FunctionSeries() { Color = OxyColor.Parse("#5a95be") };

            int sum = 500;
            for (int i = 0; i < sum; i++)
            {
                seriesP1.Points.Add(new DataPoint(jData.derivative[0][i], jData.derivative[1][i]));
            }
            modelP1.Series.Add(seriesP1);

            return modelP1;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            item = comboBox.SelectedIndex;
            jData = getData();
            plot1.Model = getModel1();
            plot2.Model = getModel2();
        }

        private string getParam(int index)
        {
            switch (index)
            {
                case 0: return "national_debt";
                case 1: return "enterprise_debt";
                case 2: return "trust_rate";
                case 3: return "trust_debt";
                case 4: return "debt_foundation";
                case 5: return "trust_debtRights";
                case 6: return "trust_stock";
                case 7: return "trust_transfer";
                case 8: return "receive";
                case 9: return "self_debtRights";
                case 10: return "bill";
                case 11: return "credit";
                case 12: return "other";
                case 13: return "cash";
                case 14: return "currency_market_tool";
                case 15: return "asset";
            }
            return "";
        }

        private JsonPartial getData()
        {
            MyEntity entity = dataPage.getEntity();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://39.108.217.238:8080/partial_history/");
            request.Method = "POST";
            var postData = "which=" + getParam(item);
            var encodeData = Encoding.ASCII.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = encodeData.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(encodeData, 0, encodeData.Length);
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            string json = streamReader.ReadToEnd();

            JsonPartial data = JsonConvert.DeserializeObject<JsonPartial>(json);

            return data;
        }
    }

}
