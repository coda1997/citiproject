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
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading;
using System.Windows.Interop;
using JumpKick.HttpLib;

namespace citi.MyPage
{
    /// <summary>
    /// ComparePage.xaml 的交互逻辑
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class ComparePage : Page
    {
        public ComparePage(MyEntity e1, MyEntity e2)
        {
            InitializeComponent();
            entity1 = e1;
            entity2 = e2;
            //getPreData();
            //webBrowser1.Navigate(uriMap);
            initView();
            


        }
        
        private void initView()
        {
            Console.WriteLine("Json: \n" + entity1.ToJson() + "\n" + entity2.ToJson());
            string content1 = new StreamReader(Constant.DeChart).ReadToEnd();
            Http.Post(Constant.OverViewUrl).Body("application/json",entity1.ToJson()).OnSuccess(haha =>
            {
                string res = processHtml(content1, haha);
                Console.WriteLine(res);
                new Thread(() =>
                {
                    //System.Threading.Thread.Sleep(2000);
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        webBrowser1.NavigateToString(res);
                    }));
                }).Start();
            }).OnFail(result =>
            {
                Console.WriteLine(result.Message);
            }).Go();


            Http.Post(Constant.OverViewUrl).Body("application/json", entity2.ToJson()).OnSuccess(haha =>
            {

                string res = processHtml(content1, haha);
                Console.WriteLine(res);
                new Thread(() =>
                {
                    System.Threading.Thread.Sleep(1000);
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        webBrowser2.NavigateToString(res);
                    }));
                }).Start();
            }).OnFail(result =>
            {
                Console.WriteLine(result);
            }).Go();
            plot3.Model = getModel3();
            plot4.Model = getModel4();

          


        }

        private string processHtml(string content,string data)
        {
            int start = content.IndexOf('@');
            string l = content.Substring(0, start);
            string m = content.Substring(start+1);
            string n = "var data = "+data;
            return l+n+m;

        }

        private MyEntity entity1;
        private MyEntity entity2;

        private PlotModel getModel1(JsonOverview data)
        {
            PlotModel modelP2 = new PlotModel { Title = " " };
            dynamic seriesP21 = new FunctionSeries() { Color = OxyColor.Parse("#5a95be") };
            dynamic seriesP22 = new LineSeries() { Color = OxyColor.Parse("#e9445f") };

            int sum = 500;
            for (int i = 0; i < sum; i++)
            {
                seriesP21.Points.Add(new DataPoint(data.points[0][i], data.points[1][i]));
            }
            seriesP22.Points.Add(new DataPoint(data.cost, 0));
            seriesP22.Points.Add(new DataPoint(data.cost, 0.3));

            modelP2.Series.Add(seriesP21);
            modelP2.Series.Add(seriesP22);

            return modelP2;
        }
        private void getPreData()
        {
            
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Constant.HistoryUrl);
            Console.WriteLine(request.Timeout);
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            string json = streamReader.ReadToEnd();
            JsonOverview data= JsonConvert.DeserializeObject<JsonOverview>(json);

            //plot1.Model = getModel1(data);
            //plot2.Model = getModel2(data);
            plot3.Model = getModel3();
            plot4.Model = getModel4();
        }

        private PlotModel getModel2(JsonOverview data)
        {
            PlotModel modelP2 = new PlotModel { Title = " " };
            dynamic seriesP21 = new FunctionSeries() { Color = OxyColor.Parse("#5a95be") };
            dynamic seriesP22 = new LineSeries() { Color = OxyColor.Parse("#e9445f") };


            int sum = 500;
            for (int i = 0; i < sum; i++)
            {
                seriesP21.Points.Add(new DataPoint(data.points[0][i], data.points[1][i]));
            }
            seriesP22.Points.Add(new DataPoint(data.cost, 0));
            seriesP22.Points.Add(new DataPoint(data.cost, 0.3));

            modelP2.Series.Add(seriesP21);
            modelP2.Series.Add(seriesP22);

            return modelP2;
        }

        private PlotModel getModel3()
        {
            string asset_standard = entity1.asset_standard;      //标准资产
            string bond = entity1.bond;
            string nonStandardAssets = entity1.nonStandardAssets;
            string cash = entity1.cash;               //现金及银行存款
            string currency_market_tool = entity1.currency_market_tool;//货币市场工具
            string asset = entity1.asset;            //权益类资产
            string other = entity1.other;

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

        private PlotModel getModel4()
        {
            string asset_standard = entity2.asset_standard;      //标准资产
            string bond = entity2.bond;
            string nonStandardAssets = entity2.nonStandardAssets;
            string cash = entity2.cash;               //现金及银行存款
            string currency_market_tool = entity2.currency_market_tool;//货币市场工具
            string asset = entity2.asset;            //权益类资产
            string other = entity2.other;

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
