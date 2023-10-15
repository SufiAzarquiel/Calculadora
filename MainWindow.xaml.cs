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
        private int currNum = 0;
        private int prevNum = 0;
        private string numStr = string.Empty;
        private Button? btn;
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
            else if (btn.Tag.ToString() == "operation")
            {
                if (!operating)
                {
                    prevNum = currNum;
                    operating = true;
                } else
                {
                    char c = btn.Content.ToString()![0];
                    switch (c)
                    {
                        case '-':
                            currNum -= prevNum;
                            break;
                        case '+':
                            currNum += prevNum;
                            break;
                        case '×':
                            currNum *= prevNum;
                            break;
                        case '÷':
                            if (prevNum == 0)
                            {
                                break;
                            }
                            currNum /= prevNum;
                            break;
                    }
                    operating = false;
                }
            }
        }

        private void SetCurrNumber()
        {
            if (btn is null)
            {
                return;
            }
            numStr += btn.Content.ToString();
            currNum = int.Parse(numStr);
        }
    }
}