using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (tbResult.Text == "0" || isOperationPerformed)
            {
                tbResult.Clear();
            }

            if (button.Text == ",")
            {
                if (!tbResult.Text.Contains(","))
                {
                    tbResult.Text += button.Text;
                }
            }
            else
            {
                tbResult.Text += button.Text;
            }
            isOperationPerformed = false;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button16.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            } else
            {
                operationPerformed = button.Text;
                resultValue = Convert.ToDouble(tbResult.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbResult.Text = "0";
            resultValue = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbResult.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    tbResult.Text = (resultValue + Convert.ToDouble(tbResult.Text)).ToString();
                    break;
                case "-":
                    tbResult.Text = (resultValue - Convert.ToDouble(tbResult.Text)).ToString();
                    break;
                case "*":
                    tbResult.Text = (resultValue * Convert.ToDouble(tbResult.Text)).ToString();
                    break;
                case "/":
                    tbResult.Text = (resultValue / Convert.ToDouble(tbResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Convert.ToDouble(tbResult.Text);
            labelCurrentOperation.Text = "";
        }
    }
}
