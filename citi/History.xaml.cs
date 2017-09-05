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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace citi
{
    /// <summary>
    /// History.xaml 的交互逻辑
    /// </summary>
    public partial class History : Window
    {


        public History()
        {
            InitializeComponent();
           // initView();




        }

        //private void  initView() {
        //    NameScope.SetNameScope(this, new NameScope());

        //    this.RegisterName("fromToAnimation",CompareBtn);

        //    DoubleAnimation doubleAnimation = new DoubleAnimation();
        //    doubleAnimation.From = 50;
        //    doubleAnimation.To = 300;
        //    doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(10));

        //    Storyboard.SetTargetName(doubleAnimation, "fromToAnimation");
        //    Storyboard.SetTargetProperty(doubleAnimation,new PropertyPath(Button.WidthProperty));

        //    Storyboard storyboard = new Storyboard();
        //    storyboard.Children.Add(doubleAnimation);

        //    CompareBtn.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
        //    {
        //        storyboard.Begin(CompareBtn);   
        //    };
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
