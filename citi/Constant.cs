using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace citi
{
    class Constant
    {
        public static readonly string RegisterUrl = "http://39.108.217.238/register/";
        public static readonly string LoginUrl = "http://39.108.217.238:8080/login/";
        public static readonly string OverViewUrl = "http://39.108.217.238:8080/overview/";
        public static readonly string PartialUrl = "http://39.108.217.238:8080/partial/";
        public static readonly string HistoryUrl = "http://39.108.217.238:8080/history/?format=json&year=2016";
        public static readonly string DeChart = "./demoCom01.html";
        public static readonly string PartialChart = "./demoCom02.html";
        public static readonly string PartialChart2 = "./demoCom03.html";

        // public static string Cookie;
        public static int MaxValue = 100;
        public static int MinValue = -1;
        public static void MinWindow()
        {
            if (Application.Current.Windows.Count > 0)
                Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }
    }
}
