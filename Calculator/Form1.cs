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
        double num1, num2, result;
        char operation;
        bool thereResult;

        public Form1()
        {
            InitializeComponent();
            EraseAll();
        }
    }
}
