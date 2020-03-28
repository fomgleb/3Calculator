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
        private void Numbers_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

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
    }
}
