using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorUI
{

    public partial class Form1 : Form
    {
        private string current_Calculation = "";
        string CLC_state = "OFF";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calculator_State();
        }

        private void btn0_Click(object sender, EventArgs e)
        {

        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btn_click(object sender, EventArgs e)
        {
            current_Calculation += (sender as System.Windows.Forms.Button).Text;
            textBox.Text = current_Calculation;
        }
        private void btn_equals_click(object sender, EventArgs e)
        {
            string formated_calculation = current_Calculation.ToString();
            
            try
            {
                if (textBox.Text.Contains("%"))
                {
                    string precentage_value = textBox.Text.Replace("%", "").Trim();

                    if(double.TryParse(precentage_value, out double result))
                    {
                        double ans = result / 100.0;
                        textBox.Text = ans.ToString();
                        textBox.Text = "%";
                        return;
                    }
                }
                if (textBox.Text.Contains("π")) 
                {
                    formated_calculation = textBox.Text.Replace("π", "3.141592653589793");
                }

                if (textBox.Text.Contains("√"))
                {
                    int index = formated_calculation.IndexOf("√");
                    string number = formated_calculation.Substring(index + 1);

                    double value = double.Parse(number);
                    double result = Math.Sqrt(value);

                    textBox.Text = result.ToString();
                    current_Calculation = "";
                    return;
                }

                if (textBox.Text.Contains("²"))
                {
                    formated_calculation = textBox.Text.Replace("²", "^2");
                }

                if (textBox.Text.Contains("³"))
                {
                    formated_calculation = textBox.Text.Replace("³", "^3");
                }

                if (formated_calculation.Contains("^"))
                {
                    string[] parts = formated_calculation.Split('^');
                    double baseNum = double.Parse(parts[0]);
                    double exponent = double.Parse(parts[1]);

                    double result = Math.Pow(baseNum, exponent);
                    textBox.Text = result.ToString();
                }
                else
                {
                    textBox.Text = new DataTable().Compute(formated_calculation, null).ToString();
                }

                current_Calculation = textBox.Text;
                current_Calculation = "";
            }
            catch (Exception ex)
            {
                textBox.Text = ex.Message.ToString();
                current_Calculation = "";
            }
        }
        private void btn_ClearAll(object sender, EventArgs e)
        {
            textBox.Text = "0";
            current_Calculation = "";
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            btn_ClearAll(sender, null);
        }
        private void btn_clear(object sender, EventArgs e)
        {
            if (current_Calculation.Length > 0)
            {
                current_Calculation = current_Calculation.Remove(current_Calculation.Length - 1, 1);
            }
            textBox.Text = current_Calculation;
            if (textBox.Text.Length <= 0) 
            {
                textBox.Text = "0"; 
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btn_clear(sender, null);
        }

        private void textBox_TextChanged_1(object sender, EventArgs e)
        {
            autoZero(sender, null);
        }
        private void autoZero(object sender, EventArgs e)
        {
            if (textBox.Text.Length < 1)
            {
                textBox.Text = "0";
            }
        }
        private string squared_symbol = "²";
        private void button3_Click(object sender, EventArgs e)
        {
            current_Calculation = squared_symbol;
            textBox.Text += squared_symbol;
            
        }
        private string cubed_symbol = "³";
        private void btnCubed_Click(object sender, EventArgs e)
        {
            current_Calculation = cubed_symbol;
            textBox.Text += cubed_symbol;
        }

        private void btnOn_Off_Click(object sender, EventArgs e)
        {
            switch (CLC_state)
            {
                case "ON":
                    CLC_state = "OFF";
                    textBox.Text = " ";
                    calculator_State();
                    break;
                case "OFF":
                    CLC_state = "ON";
                    calculator_State();
                    textBox.Text = "0";
                    autoZero(sender, null);
                    break;
            }
        }
        
        private void calculator_State()
        {
            switch (CLC_state)
            {
                case "OFF":
                    btn0.Enabled = false;
                    btn1.Enabled = false;
                    btn2.Enabled = false;
                    btn3.Enabled = false;
                    btn4.Enabled = false;
                    btn5.Enabled = false;
                    btn6.Enabled = false;
                    btn7.Enabled = false;
                    btn8.Enabled = false;
                    btn9.Enabled = false;
                    btnClear.Enabled = false;
                    btnClearAll.Enabled = false;
                    btnCubed.Enabled = false;
                    btnDivide.Enabled = false;
                    btnDot.Enabled = false;
                    btnPlus.Enabled = false;
                    btnMinus.Enabled = false;
                    btnPercentage.Enabled = false;
                    btnPi.Enabled = false;
                    btnSquared.Enabled = false;
                    btnSquareRoot.Enabled = false;
                    btnMultiply.Enabled = false;
                    btnEquals.Enabled = false;
                    btnToThePowerOf.Enabled = false;
                    current_Calculation = "";
                    break;
                case "ON":
                    btn0.Enabled = true;
                    btn1.Enabled = true;
                    btn2.Enabled = true;
                    btn3.Enabled = true;
                    btn4.Enabled = true;
                    btn5.Enabled = true;
                    btn6.Enabled = true;
                    btn7.Enabled = true;
                    btn8.Enabled = true;
                    btn9.Enabled = true;
                    btnClear.Enabled = true;
                    btnClearAll.Enabled = true;
                    btnCubed.Enabled = true;
                    btnDivide.Enabled = true;
                    btnDot.Enabled = true;
                    btnPlus.Enabled = true;
                    btnMinus.Enabled = true;
                    btnPercentage.Enabled = true;
                    btnPi.Enabled = true;
                    btnSquared.Enabled = true;
                    btnSquareRoot.Enabled = true;
                    btnMultiply.Enabled = true;
                    btnEquals.Enabled = true;
                    btnToThePowerOf.Enabled = true;
                    current_Calculation = "";
                    break;

            }
        }
    }
}
