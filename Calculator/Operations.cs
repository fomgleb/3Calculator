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
        void PlusMinusTimesDivideDegree(Button button)
        {
            if (operation != ' ')
                Equals();
            if (thereResult == true)
            {
                thereResult = false;
                labelSecondary.Text = "";
            }
            if (num2 == 0)
            {
                operation = Convert.ToChar(button.Text);
                num1 = Convert.ToDouble(labelMain.Text);
                labelSecondary.Text += labelMain.Text;
                labelSecondary.Text += button.Text;
                labelMain.Text = "0";
            }
        }

        void Root()
        {
            result = Math.Sqrt(Convert.ToDouble(labelMain.Text));
            richTextBox1.AppendText($"sqrt({labelMain.Text}) =  {result}" + "\n\n");
            labelSecondary.Text = $"sqrt({labelMain.Text}) =";
            labelMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void Negate()
        {
            result = Convert.ToDouble(labelMain.Text) * -1;
            richTextBox1.AppendText($"negate({labelMain.Text}) =  " + result + "\n\n");
            labelMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void OneDividedBy()
        {
            result = 1 / Convert.ToDouble(labelMain.Text);
            richTextBox1.AppendText($"1/{labelMain.Text} =  {result}" + "\n\n");
            labelSecondary.Text = $"1/{labelMain.Text}=";
            labelMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void Percent()
        {
            if (operation == '+' || operation == '-')
            {
                result = num1 * (Convert.ToDouble(labelMain.Text) / 100);
                labelMain.Text = Convert.ToString(result);
            }
            else if (operation == '×' || operation == '÷')
            {
                result = Convert.ToDouble(labelMain.Text) * 0.01;
                labelMain.Text = Convert.ToString(result);
            }
        }

        void Numbers(Button button)
        {
            if (button.Text == ",")
            {
                if (!labelMain.Text.Contains(","))
                    labelMain.Text = labelMain.Text + button.Text;
            }
            else
            {
                if (labelMain.Text == "0")
                    labelMain.Text = "";
                labelMain.Text += button.Text;
            }
        }

        public void Equals()
        {
            try
            {
                num2 = Convert.ToDouble(labelMain.Text);

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
                    labelSecondary.Text += labelMain.Text + "=";
                    labelMain.Text = Convert.ToString(result);

                    richTextBox1.AppendText(num1 + Convert.ToString(operation) + num2 + " =  ");
                    int len = Convert.ToString(num1 + operation + num2 + " = " + result).Length;
                    richTextBox1.AppendText(result + "\n\n");

                    num1 = result;
                }
                else
                    num1 = 0;
                num2 = 0;
                operation = ' ';
            }
            catch (Exception)
            {
            }
        }

        void Erase()
        {
            var len = labelMain.Text.Length;
            if (labelMain.Text != "0")
                labelMain.Text = labelMain.Text.Remove(len - 1);
            if (labelMain.Text == "")
                labelMain.Text = "0";
        }

        void EraseAll()
        {
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = ' ';
            labelMain.Text = "0";
            labelSecondary.Text = "";
            thereResult = false;
        }
    }
}
