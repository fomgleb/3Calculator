using System;
using System.Globalization;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        double num1, num2, result;
        char operation;
        bool thereResult;

        public MainForm()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            EraseAll();
        }

        #region ButtonsClick
        //Клик мышей по оператору
        private void OperationButton_Click(object sender, EventArgs e)
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
        void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Numbers(button);
        }

        //Нажатие на клавиатуре
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
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
        //Нажатия на клавиатуре системных клавиш
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: EraseAll(); break;
                case Keys.Return: Equals(); break;
                case Keys.Delete: richTextBox1.Text = ""; break;
            }
        }
        #endregion

        #region Operations
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

            string historySave = richTextBox1.Text;
            richTextBox1.Text = $"sqrt({TextBoxMain.Text}) =  {result}" + "\n\n";
            richTextBox1.Text += historySave;

            labelSecondary.Text = $"sqrt({TextBoxMain.Text}) =";
            TextBoxMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void Negate()
        {
            result = Convert.ToDouble(TextBoxMain.Text) * -1;

            string historySave = richTextBox1.Text;
            richTextBox1.Text = $"negate({TextBoxMain.Text}) =  " + result + "\n\n";
            richTextBox1.Text += historySave;

            TextBoxMain.Text = Convert.ToString(result);
            thereResult = true;
        }

        void OneDividedBy()
        {
            result = 1 / Convert.ToDouble(TextBoxMain.Text);

            string historySave = richTextBox1.Text;
            richTextBox1.Text = $"1/{TextBoxMain.Text} =  {result}" + "\n\n";
            richTextBox1.Text += historySave;

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

                    string historySave = richTextBox1.Text;
                    richTextBox1.Text = $"{num1} {operation} {num2} = {result}\n\n";
                    richTextBox1.Text += historySave;

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

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (Width < 650)
                tableLayoutPanel4.ColumnCount = 1;
            else
                tableLayoutPanel4.ColumnCount = 2;
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
        #endregion
    }
}
