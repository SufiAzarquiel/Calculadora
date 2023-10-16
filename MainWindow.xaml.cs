using System.Threading;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Store a number in memory and an operation, then operate
    /// Possible bugs if app not used in that order
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currNum = 0;
        private double prevNum = 0;
        private string numStr = string.Empty;
        private Button? btn;
        private char currOperation;
        private bool operating = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "num":
                    SetCurrNumber();
                    break;
                case "point":
                    AddPoint();
                    break;
                case "operation":
                    Operate();
                    break;
            }

            if (btn.Content.ToString()![0] == '=')
            {
                currNum = 0;
                operating = false;
            }
        }

        private void Operate()
        {
            if (!operating)
            {
                operating = true;
            }
            else
            {
                UpdateCurrNum();
            }
            currOperation = btn!.Content.ToString()![0];
            numStr = string.Empty;
            prevNum = currNum;
            ShowNum();
        }

        private void UpdateCurrNum()
        {
            switch (currOperation)
            {
                case '-':
                    currNum = prevNum - currNum;
                    break;
                case '+':
                    currNum += prevNum;
                    break;
                case '×':
                    currNum *= prevNum;
                    break;
                case '÷':
                    if (currNum == 0)
                    {
                        break;
                    }
                    currNum = prevNum / currNum;
                    break;
            }
        }

        private void AddPoint()
        {
            if (!numStr.Contains('.'))
            {
                // Get current decimal separator
                char a = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                numStr += a;
                lblNum.Content = numStr;
            }
        }

        private void ShowNum()
        {
            lblStack.Content = prevNum.ToString(Thread.CurrentThread.CurrentCulture);
            lblNum.Content = currNum.ToString(Thread.CurrentThread.CurrentCulture);
        }

        private void SetCurrNumber()
        {
            if (btn is null)
            {
                return;
            }
            numStr += btn.Content.ToString();
            currNum = double.Parse(numStr, System.Globalization.NumberStyles.AllowDecimalPoint);
            ShowNum();
        }
    }
}