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
                num1 = Convert.ToDouble(TextBoxMain.Text);
                labelSecondary.Text += TextBoxMain.Text;
                labelSecondary.Text += button.Text;
                TextBoxMain.Text = "0";
            }
        }

        void Root()
        {
            result = Math.Sqrt(Convert.ToDouble(TextBoxMain.Text));
            richTextBox1.AppendText($"sqrt({TextBoxMain.Text}) =  {result}" + "\n\n");
            labelSecondary.Text = $"sqrt({TextBoxMain.Text}) =";
            TextBoxMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void Negate()
        {
            result = Convert.ToDouble(TextBoxMain.Text) * -1;
            richTextBox1.AppendText($"negate({TextBoxMain.Text}) =  " + result + "\n\n");
            TextBoxMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void OneDividedBy()
        {
            result = 1 / Convert.ToDouble(TextBoxMain.Text);
            richTextBox1.AppendText($"1/{TextBoxMain.Text} =  {result}" + "\n\n");
            labelSecondary.Text = $"1/{TextBoxMain.Text}=";
            TextBoxMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void Percent()
        {
            if (operation == '+' || operation == '-')
            {
                result = num1 * (Convert.ToDouble(TextBoxMain.Text) / 100);
                TextBoxMain.Text = Convert.ToString(result);
            }
            else if (operation == '×' || operation == '÷')
            {
                result = Convert.ToDouble(TextBoxMain.Text) * 0.01;
                TextBoxMain.Text = Convert.ToString(result);
            }
        }

        void Numbers(Button button)
        {
            if (button.Text == ",")
            {
                if (!TextBoxMain.Text.Contains(","))
                    TextBoxMain.Text += button.Text;
            }
            else
            {
                if (TextBoxMain.Text == "0")
                    TextBoxMain.Text = "";
                TextBoxMain.Text += button.Text;
            }
        }

        public void Equals()
        {
            try
            {
                num2 = Convert.ToDouble(TextBoxMain.Text);

                switch (operation)
                {
                    case '+': result = num1 + num2; thereResult = true; break;
                    case '-': result = num1 - num2; thereResult = true; break;
                    case '×': result = num1 * num2; thereResult = true; break;
                    case '÷': result = num1 / num2; thereResult = true; break;
                    case '^': result = Math.Pow(num1, num2); thereResult = true; break;
                    default: break;
                }
                if (thereResult == true && operation != ' ')
                {
                    labelSecondary.Text += TextBoxMain.Text + "=";
                    TextBoxMain.Text = Convert.ToString(result);

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
            var len = TextBoxMain.Text.Length;
            if (TextBoxMain.Text != "0")
                TextBoxMain.Text = TextBoxMain.Text.Remove(len - 1);
            if (TextBoxMain.Text == "")
                TextBoxMain.Text = "0";
        }

        void EraseAll()
        {
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = ' ';
            TextBoxMain.Text = "0";
            labelSecondary.Text = "";
            thereResult = false;
        }
    }
}
