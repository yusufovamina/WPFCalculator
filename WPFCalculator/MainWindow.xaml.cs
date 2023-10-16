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
                textBlockCalcEquation.Text = "";
                textBlockCalc.Text = "";
            }
            else if (res=="CE")
            { char[] arr = new char[] { '+', '-','/','*'} ;
               int index= textBlockCalcEquation.Text.IndexOfAny(arr);
                if (index >= 0)
                {
                    textBlockCalcEquation.Text = textBlockCalcEquation.Text.Substring(0, index + 1);
                    textBlockCalc.Text = "";
                }
                else
                {
                   
                    textBlockCalcEquation.Text = "";
                    textBlockCalc.Text = "";
                }
            
            }
            else if(res == "=")
                {
                string finalCalcResult=new DataTable().Compute(textBlockCalcEquation.Text, null).ToString();
                textBlockCalc.Text = "";
                textBlockCalc.Text = finalCalcResult;
            }
            else if (res == ">")
            {
                textBlockCalcEquation.Text= textBlockCalcEquation.Text.Substring(0,textBlockCalcEquation.Text.Length-1);
            }
            else
            {
                textBlockCalcEquation.Text += res;
            }
        }
        
    }
}
