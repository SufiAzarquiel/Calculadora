using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float currNum = 0;
        private float prevNum = 0;
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
            if (btn.Tag is null)
            {
                lblStack.Content = "";
                lblNum.Content = "0";
            }
            else if (btn.Tag.ToString() == "num")
            {
                SetCurrNumber();
            }
            else if (btn.Tag.ToString() == "point")
            {
                if (!numStr.Contains('.'))
                {
                    numStr += ',';
                }
            }
            else if (btn.Tag.ToString() == "operation")
            {
                if (!operating)
                {
                    operating = true;
                } else
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
                currOperation = btn.Content.ToString()![0];
                numStr = string.Empty;
                prevNum = currNum;
            }
            ShowNum();
            if (btn.Content.ToString()![0] == '=')
            {
                currNum = 0;
                operating = false;
            }
        }

        private void ShowNum()
        {
            lblStack.Content = prevNum;
            lblNum.Content = currNum;
        }

        private void SetCurrNumber()
        {
            if (btn is null)
            {
                return;
            }
            numStr += btn.Content.ToString();
            currNum = float.Parse(numStr, System.Globalization.NumberStyles.AllowDecimalPoint);
        }
    }
}