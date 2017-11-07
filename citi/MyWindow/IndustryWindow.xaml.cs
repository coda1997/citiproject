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
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;
using Newtonsoft.Json;
using JumpKick.HttpLib;
using System.Net;
using System.Threading;
using System.IO;
using DMSkin.WPF;


namespace citi.MyWindow
{
    /// <summary>
    /// IndustryWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IndustryWindow : DMSkinWindow
    {
        public IndustryWindow(int year)
        {
            InitializeComponent();
            
            getModel2(year);
            plot1.Model = getModel1(year);
        }

        private PlotModel getModel1(int year)
        {
            double[] pieData = getPieData(year);

            double asset_standard = pieData[0];
            double bond = pieData[1];
            double nonStandardAssets = pieData[2];
            double cash = pieData[3];
            double currency_market_tool = pieData[4];
            double asset = pieData[5];
            double other = pieData[6];

            PlotModel modelP1 = new PlotModel { Title = " " };
            dynamic seriesP1 = new PieSeries { StrokeThickness = 1, AngleSpan = 360, StartAngle = 0 };
            seriesP1.Slices.Add(new PieSlice("", asset_standard) { Fill = OxyColor.Parse("#5a95be") });
            seriesP1.Slices.Add(new PieSlice("", bond) { Fill = OxyColor.Parse("#b4bbd5") });
            seriesP1.Slices.Add(new PieSlice("", nonStandardAssets) { Fill = OxyColor.Parse("#9DA5BE") });
            seriesP1.Slices.Add(new PieSlice("", cash) { Fill = OxyColor.Parse("#8691A7") });
            seriesP1.Slices.Add(new PieSlice("", currency_market_tool) { Fill = OxyColor.Parse("#717D90") });
            seriesP1.Slices.Add(new PieSlice("", asset) { Fill = OxyColor.Parse("#5A6777") });
            seriesP1.Slices.Add(new PieSlice("", other) { Fill = OxyColor.Parse("#d5d5d5") });
            modelP1.Series.Add(seriesP1);

            return modelP1;
        }





        private void getModel2(int year)
        {
            new Thread(() => 
            {

                PlotModel modelP2 = new PlotModel { Title = " " };
                dynamic seriesP21 = new FunctionSeries() { Color = OxyColor.Parse("#5a95be") };
                dynamic seriesP22 = new LineSeries() { Color = OxyColor.Parse("#e9445f") };

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(geturl(year));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string json = streamReader.ReadToEnd();
                JsonOverview data = JsonConvert.DeserializeObject<JsonOverview>(json);
                string content = new StreamReader(Constant.IndustryChart).ReadToEnd();
                string res = WebHelper.processHTML(content, json);
                Console.WriteLine(res);
         
                this.Dispatcher.Invoke(new Action(() =>
                {
                    label2.Content = "违约概率：" + (Convert.ToDouble(data.probability) * 100).ToString("f2") + "%";
                    webBroswer.NavigateToString(res);
                }));
                
            }).Start();

      
        }



        private double[] getPieData(int year)
        {
            double [] data16 = { 232253200, 73490544, 29372706, 27878040, 22067316, 15097806, 5097806 };
            double [] data15 = { 8.42, 0.32, 0.12, 0.23, 0.22, 0.08, 0.03 };
            double [] data14 = { 10.6, 0.29, 0.20, 0.26, 0.13, 0.08, 0.03 };

            if (year == 2016)
                return data16;
            else if (year == 2015)
                return data15;
            else if (year == 2014)
                return data14;

            return data16;
        }

        private string geturl(int year)
        {
            string url14 = "http://39.108.217.238:8080/history/?format=json&year=2014";
            string url15 = "http://39.108.217.238:8080/history/?format=json&year=2015";
            string url16 = "http://39.108.217.238:8080/history/?format=json&year=2016";

            if (year == 2014)
                return url14;
            else if (year == 2015)
                return url15;
            else
                return url16;
        }


    }
}
