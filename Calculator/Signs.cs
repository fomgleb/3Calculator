using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public partial class Form1
    {
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            labelClear();
            if (num1 != 0 && sign != ' ')
            {
                Equals();
            }
            if (num2 == 0 && labelMain.Text != "0")
            {
                sign = '+';
                num1 = Convert.ToDouble(labelMain.Text);
                labelSecondary.Text += labelMain.Text;
                labelSecondary.Text += "+";
                labelMain.Text = "0";
            }
            if (num1 != 0 && sign != ' ')
            {
                num2 = Convert.ToDouble(labelMain.Text);
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonTimes_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDivided_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDegree_Click(object sender, EventArgs e)
        {
            
        }
    }
}
