using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public partial class Form1
    {
        public void Equals()
        {
            try
            {
                labelClear();
                num2 = Convert.ToDouble(labelMain.Text);

                labelSecondary.Text += labelMain.Text + "=";

                switch (sign)
                {
                    case '+': result = num1 + num2; thereResult = true; break;
                    case '-': result = num1 - num2; thereResult = true; break;
                    case '*': result = num1 * num2; thereResult = true; break;
                    case '/': result = num1 / num2; thereResult = true; break;
                    case '^': result = Math.Pow(num1, num2); thereResult = true; break;
                    default: thereResult = false; break;
                }
                if (thereResult == true)
                {
                    labelMain.Text = Convert.ToString(result);
                    num1 = result;
                }
                else
                    num1 = 0;
                num2 = 0;
                sign = ' ';
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
