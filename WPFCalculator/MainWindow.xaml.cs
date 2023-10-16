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
using System.Data;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement item in MainGrid.Children) {
                if (item is Button) {
                    ((Button)item).Click += Button_CLick;
                }
            }
        }

        private void Button_CLick(object sender, RoutedEventArgs e)
        {
            string res =(string)((Button)e.OriginalSource).Content;
          
            if (res == "C")
            {
                textBlockCalc.Text = "";
            }
            else if(res == "=")
                {
                string finalCalcResult=new DataTable().Compute(textBlockCalc.Text, null).ToString();
                textBlockCalc.Text = "";
                textBlockCalc.Text = finalCalcResult;
            }
            else
            {
                textBlockCalc.Text += res;
            }
        }
        
    }
}
