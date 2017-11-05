using JumpKick.HttpLib;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace citi
{
    class WebHelper
    {
        public static void ConstructHTML(Page p,WebBrowser webBrowser, String url, MyEntity entity, String webSource) {
            string content = new StreamReader(webSource).ReadToEnd();
            Http.Post(url).Form(JsonConvert.SerializeObject(entity)).OnSuccess(result =>
            {
                string res = processHTML(content, result);
                new Thread(() =>
                {
                    p.Dispatcher.Invoke(new Action(() =>
                    {
                        webBrowser.NavigateToString(res);
                    }));
                }).Start();

            }).OnFail(result =>
            {
                Console.WriteLine(":post chart failed" + result);
            }).Go();
        }
        public static void ConstructHTML(Page p, WebBrowser webBrowser, String url, String webSource)
        {
            string content = new StreamReader(webSource).ReadToEnd();
            Http.Get(url).OnSuccess(result =>
            {
                string res = processHTML(content, result);
                new Thread(() =>
                {
                    p.Dispatcher.Invoke(new Action(() =>
                    {
                        webBrowser.NavigateToString(res);
                    }));
                }).Start();

            }).OnFail(result =>
            {
                Console.WriteLine(":post chart failed" + result);
            }).Go();
        }
        public static string processHTML(string content, string data)
        {
            int start = content.IndexOf('@');
            string l = content.Substring(0, start);
            string m = content.Substring(start + 1);
            string n = "var data = " + data;
            return l + n + m;
        }
       
    }
}
