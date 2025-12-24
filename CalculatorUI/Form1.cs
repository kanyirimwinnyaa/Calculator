using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorUI
{
    public partial class Form1 : Form
    {
        private string current_Calculation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            current_Calculation += (sender as Button).Text;
            textBox.Text = current_Calculation;
        }
        private void btn_equals_click(object sender, EventArgs e)
        {
            string formated_calculation = current_Calculation.ToString();
            try
            {
                textBox.Text = new DataTable().Compute(formated_calculation, null).ToString();
                current_Calculation = textBox.Text;
            }
            catch (Exception)
            {
                textBox.Text = "Error";
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btn_clear(sender, null);
        }
    }
}
