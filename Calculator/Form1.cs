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
        double num1, num2, result;
        char operation = ' ';
        bool thereResult;

        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        void Reset()
        {
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = ' ';
            labelMain.Text = "";
            labelSecondary.Text = "";
            thereResult = false;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Equals();
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
        }

        private void buttonComa_Click(object sender, EventArgs e)
        {
            if (labelMain.Text.IndexOf(',') == -1)
            {
                labelMain.Text += ",";
            }
        }

        

        private void buttonEarseAll_Click(object sender, EventArgs e)
        {
            labelMain.Text = "0";
            labelSecondary.Text = "";
            num1 = 0;
            num2 = 0;
            operation = ' ';
        }

        private void ButtonHistoryClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonEarselabelWrite_Click(object sender, EventArgs e)
        {
            labelMain.Text = "0";
        }

        

        void labelClear()
        {
            while (labelSecondary.Text.Length > 15)
            {
                labelSecondary.Text = labelSecondary.Text.Remove(0, 1);
            }
        }
    }
}
