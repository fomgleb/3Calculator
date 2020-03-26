using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public partial class Form1
    {
        private void button1_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "1";
            labelMain.Text = _labelMain;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "2";
            labelMain.Text = _labelMain;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "3";
            labelMain.Text = _labelMain;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "4";
            labelMain.Text = _labelMain;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "5";
            labelMain.Text = _labelMain;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "6";
            labelMain.Text = _labelMain;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "7";
            labelMain.Text = _labelMain;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "8";
            labelMain.Text = _labelMain;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "9";
            labelMain.Text = _labelMain;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (labelMain.Text == "0")
            {
                labelMain.Text = "";
                _labelMain = "";
            }
            _labelMain += "0";
            labelMain.Text = _labelMain;
        }
    }
}
