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
                case "CE": labelMain.Text = "0"; break;
                case "Clear": richTextBox1.Clear(); break;
                default: PlusMinusTimesDivideDegree(button); break;
            }
        }

        void ButtonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Numbers(button);
        }
    }
}
