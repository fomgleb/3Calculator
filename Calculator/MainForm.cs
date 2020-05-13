using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        double num1, num2, result;
        char operation;
        bool numInMainTextBox = false;
        string[] AllNumbersMassive = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "" };
        string[] AllOperationsMassive = { "+", "-", "×", "÷", "^", "" };

        public MainForm()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right; // Чтобы текст в "История" был справа
        }



        #region ButtonsClick
        //Нажатия мышей на кнопку
        private void AllButtons_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            switch (button.Text)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    if (numInMainTextBox == false)
                        mainTextBox.Text = button.Text;
                    else
                        mainTextBox.Text += button.Text;
                    numInMainTextBox = true;
                    break;

                case ",":
                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] != ',')
                    {
                        mainTextBox.Text += ",";
                        numInMainTextBox = true;
                    }
                    break;

                case "+/-":
                    if (mainTextBox.Text[0] == '-')
                        mainTextBox.Text = mainTextBox.Text.Remove(0, 1);
                    else
                        mainTextBox.Text = mainTextBox.Text.Insert(0, "-"); 
                    break;

                case "1/x":
                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] != ',')
                        mainTextBox.Text = Convert.ToString(1 / Convert.ToDouble(mainTextBox.Text));
                    else
                        mainTextBox.Text = Convert.ToString(1 / Convert.ToDouble(mainTextBox.Text.Remove(mainTextBox.Text.Length - 1)));
                    break;

                case "×":
                case "÷":
                case "+":
                case "-":
                case "^":
                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] == ',')
                        mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1);

                    if (secondaryLabel.Text != "" && mainTextBox.Text == "0" && secondaryLabel.Text[secondaryLabel.Text.Length - 3] != ' ')
                    {
                        char[] operations = { '×', '÷', '+', '-', '^' };
                        foreach (var operation in operations)
                            if (secondaryLabel.Text[secondaryLabel.Text.Length - 2] == operation)
                            {
                                secondaryLabel.Text = secondaryLabel.Text.Remove(secondaryLabel.Text.Length - 3);
                                break;
                            }
                    }

                    secondaryLabel.Text += $"{mainTextBox.Text} {button.Text} ";

                    int spacesCount = 0;
                    foreach (var symbol in secondaryLabel.Text)
                        if (symbol == ' ')
                            spacesCount++;

                    if (spacesCount > 2)
                        result = Calculate(secondaryLabel.Text);

                    mainTextBox.Text = result.ToString();
                    numInMainTextBox = false;
                    break;
            }
        }

        //Нажатие на клавиатуре
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //Нажатия на клавиатуре системных клавиш
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion

        private double Calculate(string input)
        {
            double num1, num2;
            double result = 0;
            List<string> operationsList = new List<string>(input.Split(' '));
            List<string> numbersList = new List<string>(input.Split(' '));

            foreach (var operation in AllOperationsMassive)
                numbersList.RemoveAll(x => x == operation);
            foreach (var operation in AllOperationsMassive)
                operationsList.RemoveAll(x => x != operation);

            if (operationsList.Count >= numbersList.Count)
                operationsList.RemoveAt(operationsList.Count - 1);

            if (numbersList.Count > 1)
            {
                while (operationsList.IndexOf("^") != -1)
                {
                    int indexOfOpeation = operationsList.IndexOf("^");
                    int indexOfNum1 = indexOfOpeation;
                    int indexOfNum2 = indexOfOpeation + 1;
                    num1 = Convert.ToDouble(numbersList[indexOfNum1]);
                    num2 = Convert.ToDouble(numbersList[indexOfNum2]);
                    result = Math.Pow(num1, num2);

                    numbersList.RemoveAt(indexOfNum2);
                    numbersList.RemoveAt(indexOfNum1);

                    operationsList.RemoveAt(indexOfOpeation);

                    numbersList.Insert(indexOfNum1, result.ToString());
                }

                while (operationsList.IndexOf("×") != -1 || operationsList.IndexOf("÷") != -1)
                {
                    if ((operationsList.IndexOf("÷") > operationsList.IndexOf("×") && operationsList.IndexOf("×") != -1) || operationsList.IndexOf("÷") == -1)
                    {
                        int indexOfOpeation = operationsList.IndexOf("*");
                        int indexOfNum1 = indexOfOpeation;
                        int indexOfNum2 = indexOfOpeation + 1;
                        num1 = Convert.ToDouble(numbersList[indexOfNum1]);
                        num2 = Convert.ToDouble(numbersList[indexOfNum2]);
                        result = num1 * num2;

                        numbersList.RemoveAt(indexOfNum2);
                        numbersList.RemoveAt(indexOfNum1);

                        operationsList.RemoveAt(indexOfOpeation);

                        numbersList.Insert(indexOfNum1, result.ToString());
                    }
                    else if ((operationsList.IndexOf("×") > operationsList.IndexOf("÷") && operationsList.IndexOf("÷") != -1) || operationsList.IndexOf("×") == -1)
                    {
                        int indexOfOpeation = operationsList.IndexOf("÷");
                        int indexOfNum1 = indexOfOpeation;
                        int indexOfNum2 = indexOfOpeation + 1;
                        num1 = Convert.ToDouble(numbersList[indexOfNum1]);
                        num2 = Convert.ToDouble(numbersList[indexOfNum2]);
                        result = num1 / num2;

                        numbersList.RemoveAt(indexOfNum2);
                        numbersList.RemoveAt(indexOfNum1);

                        operationsList.RemoveAt(indexOfOpeation);

                        numbersList.Insert(indexOfNum1, result.ToString());
                    }
                }

                while (operationsList.IndexOf("+") != -1 || operationsList.IndexOf("-") != -1)
                {
                    if ((operationsList.IndexOf("-") > operationsList.IndexOf("+") && operationsList.IndexOf("+") != -1) || operationsList.IndexOf("-") == -1)
                    {
                        int indexOfOpeation = operationsList.IndexOf("+");
                        int indexOfNum1 = indexOfOpeation;
                        int indexOfNum2 = indexOfOpeation + 1;
                        num1 = Convert.ToDouble(numbersList[indexOfNum1]);
                        num2 = Convert.ToDouble(numbersList[indexOfNum2]);
                        result = num1 + num2;

                        numbersList.RemoveAt(indexOfNum2);
                        numbersList.RemoveAt(indexOfNum1);

                        operationsList.RemoveAt(indexOfOpeation);

                        numbersList.Insert(indexOfNum1, result.ToString());
                    }
                    else if ((operationsList.IndexOf("+") > operationsList.IndexOf("-") && operationsList.IndexOf("-") != -1) || operationsList.IndexOf("+") == -1)
                    {
                        int indexOfOpeation = operationsList.IndexOf("-");
                        int indexOfNum1 = indexOfOpeation;
                        int indexOfNum2 = indexOfOpeation + 1;
                        num1 = Convert.ToDouble(numbersList[indexOfNum1]);
                        num2 = Convert.ToDouble(numbersList[indexOfNum2]);
                        result = num1 - num2;

                        numbersList.RemoveAt(indexOfNum2);
                        numbersList.RemoveAt(indexOfNum1);

                        operationsList.RemoveAt(indexOfOpeation);

                        numbersList.Insert(indexOfNum1, result.ToString());
                    }
                }
            }

            return result;
        }
    }
}
