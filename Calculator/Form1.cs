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
        public double num1 = 0, num2 = 0, result;
        public char sign = ' ';
        public string _labelMain, _labelSecondary;
        bool thereResult = false;

        public Form1()
        {
            InitializeComponent();
            Restart();
        }

        public void Restart()
        {
            labelMain.Text = "0";
            labelSecondary.Text = "";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Equals();
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            Erase(_labelMain);
        }

        private void buttonComa_Click(object sender, EventArgs e)
        {
            if (labelMain.Text.IndexOf(',') == -1)
            {
                labelMain.Text += ",";
                _labelMain += ",";
            }
        }

        

        private void buttonEarseAll_Click(object sender, EventArgs e)
        {
            _labelMain = "";
            labelMain.Text = "0";
            labelSecondary.Text = "";
            _labelSecondary = "";
            num1 = 0;
            num2 = 0;
            sign = ' ';
        }

        private void buttonEarselabelWrite_Click(object sender, EventArgs e)
        {
            _labelMain = "";
            labelMain.Text = "";
        }

        void labelUpdate()
        {
            _labelMain = labelMain.Text;
            _labelSecondary = labelSecondary.Text;
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
