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

namespace citi
{
    /// <summary>
    /// AddAnaDetail02.xaml 的交互逻辑
    /// </summary>
    public partial class AddAnaDetail02 : Page
    {
        public AddAnaDetail02()
        {
            InitializeComponent();
        }
        public string National_debt { get { return national_debt.Text; }  }
        public string Enterprise_debt { get { return enterprise_debt.Text; } }

    }
}