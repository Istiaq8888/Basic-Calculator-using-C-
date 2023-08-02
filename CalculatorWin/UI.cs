using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryCalculations;

namespace CalculatorWin
{
    public partial class UI : Form
    {
        private Calculator calculator;

        private bool isOperationClicked = false;
        private bool isDecimalClicked = false;

        public UI()
        {
            InitializeComponent();
            calculator = new Calculator();
            isOperationClicked = false;
            isDecimalClicked = false;
        }

        private void button_click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            if (textBox_Result.Text == "0" || isOperationClicked)
            {
                textBox_Result.Text = button.Text;
                isOperationClicked = false;
            }
            else
            {
                textBox_Result.Text += button.Text;
            }

        }


        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                double num = Convert.ToDouble(textBox_Result.Text);
                calculator.PerformOperation(num);
            }
            catch (Exception ex)
            {
                textBox_Result.Text = "Error";
                labelCurrentOperation.Text = "";
            }
            calculator.SetCurrentOperation(button.Text);
            labelCurrentOperation.Text = textBox_Result.Text + " " + button.Text;
            isOperationClicked = true;
            isDecimalClicked = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {

            try
            {
                double num = Convert.ToDouble(textBox_Result.Text);
                double result = calculator.PerformOperation(num);
                textBox_Result.Text = result.ToString();
                labelCurrentOperation.Text = "";
            }
            catch (Exception ex)
            {
                textBox_Result.Text = "Error";
                labelCurrentOperation.Text = "";
            }
            isDecimalClicked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            isDecimalClicked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            textBox_Result.Text = "0";
            labelCurrentOperation.Text = "";
            isOperationClicked = false;
            isDecimalClicked = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!isDecimalClicked)
            {
                textBox_Result.Text += ".";
                isDecimalClicked = true;
            }
        }
    }
}