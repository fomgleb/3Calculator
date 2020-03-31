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
        //Клик мышей по оператору
        private void ButtonOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Text)
            {
                case "=": Equals(); break;
                case "√": Root(); break;
                case "%": Percent(); break;
                case "1/x": OneDividedBy(); break;
                case "+/-": Negate(); break;
                case "C": EraseAll(); break;
                case "⌫": Erase(); break;
                case "CE": TextBoxMain.Text = "0"; break;
                case "Clear": richTextBox1.Clear(); break;
                default: PlusMinusTimesDivideDegree(button); break;
            }
        }
        //Клик мышей по числу
        void ButtonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Numbers(button);
        }
        //Нажатие на клавиатуре
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            Button button = new Button();

            switch (key)
            {
                case '1': button.Text = "1"; Numbers(button); break;
                case '2': button.Text = "2"; Numbers(button); break;
                case '3': button.Text = "3"; Numbers(button); break;
                case '4': button.Text = "4"; Numbers(button); break;
                case '5': button.Text = "5"; Numbers(button); break;
                case '6': button.Text = "6"; Numbers(button); break;
                case '7': button.Text = "7"; Numbers(button); break;
                case '8': button.Text = "8"; Numbers(button); break;
                case '9': button.Text = "9"; Numbers(button); break;
                case '0': button.Text = "0"; Numbers(button); break;
                case ',': button.Text = ","; Numbers(button); break;
                
                case '+': button.Text = "+"; PlusMinusTimesDivideDegree(button); break;
                case '-': button.Text = "-"; PlusMinusTimesDivideDegree(button); break;
                case '*': button.Text = "×"; PlusMinusTimesDivideDegree(button); break;
                case '/': button.Text = "÷"; PlusMinusTimesDivideDegree(button); break;
                case '^': button.Text = "^"; PlusMinusTimesDivideDegree(button); break;

                case 'n': Negate(); break;
                case '%': Percent(); break;
                case 'r': Root(); break;
                case 'd': OneDividedBy(); break;

                case '\b': Erase(); break;

                default: break;
            }
        }
        //Системные клавиши
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: EraseAll(); break;
                case Keys.Return: Equals(); break;
                case Keys.Delete: richTextBox1.Text = ""; break;
            }
        }
    }
}
