using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1
    {
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            labelClear();
            if (operation != ' ')
                Equals();
            if (num2 == 0)
            {
                operation = Convert.ToChar(button.Text);
                num1 = Convert.ToDouble(labelMain.Text);
                labelSecondary.Text += labelMain.Text;
                labelSecondary.Text += button.Text;
                labelMain.Text = "0";
            }
            if (num1 != 0 && operation != ' ')
            {
                num2 = Convert.ToDouble(labelMain.Text);
            }
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            result = Math.Sqrt(Convert.ToDouble(labelMain.Text));
            richTextBox1.AppendText($"Sqrt({labelMain.Text}) =  {result}" + "\n\n");
            labelSecondary.Text = $"Sqrt({labelMain.Text}) =";
            labelMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        private void buttonNegate_Click(object sender, EventArgs e)
        {
            result = Convert.ToDouble(labelMain.Text) * -1;
            richTextBox1.AppendText($"Reverse({labelMain.Text}) =  " + result + "\n\n");
            labelSecondary.Text = "";
            labelMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        private void buttonOneDividedBy_Click(object sender, EventArgs e)
        {
            result = 1 / Convert.ToDouble(labelMain.Text);
            richTextBox1.AppendText($"1/{labelMain.Text} =  {result}" + "\n\n");
            labelSecondary.Text = $"1/{labelMain.Text}=";
            labelMain.Text = Convert.ToString(result);
        }

        public void Equals()
        {
            try
            {
                labelClear();
                num2 = Convert.ToDouble(labelMain.Text);

                labelSecondary.Text += labelMain.Text + "=";

                switch (operation)
                {
                    case '+': result = num1 + num2; thereResult = true; break;
                    case '-': result = num1 - num2; thereResult = true; break;
                    case '×': result = num1 * num2; thereResult = true; break;
                    case '÷': result = num1 / num2; thereResult = true; break;
                    case '^': result = Math.Pow(num1, num2); thereResult = true; break;
                    default: thereResult = false; break;
                }
                if (thereResult == true)
                {
                    labelMain.Text = Convert.ToString(result);

                    ButtonHistoryClear.Visible = true;
                    richTextBox1.AppendText(num1 + Convert.ToString(operation) + num2 + " =  ");
                    int len = Convert.ToString(num1 + operation + num2 + " = " + result).Length;
                    richTextBox1.AppendText(result + "\n\n");

                    num1 = result;
                }
                else
                    num1 = 0;
                num2 = 0;
                operation = ' ';

                labelSecondary.Text = "";
            }
            catch (Exception)
            {
            }
        }

        public string Erase(string label)
        {
            try
            {
                int l = label.Length - 1;
                label = label.Remove(l);
                return label;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
