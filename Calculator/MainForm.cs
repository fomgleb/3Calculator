using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        bool numInMainTextBox = false;
        

        public MainForm()
        {
            InitializeComponent();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right; // Чтобы текст в "История" был справа
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (Width < 651)
                tableLayoutPanel4.ColumnCount = 1;
            else
                tableLayoutPanel4.ColumnCount = 2;
        }

        #region ButtonsClick
        //Нажатия мышей на кнопку
        private void AllButtons_Click(object sender, EventArgs e)
        {
            var button = (Button)sender; // нажатая кнопка на форме

            switch (button.Text)
            {
                case "1": // просто записывает цифры в главную строку
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    if (mainTextBox.Text == "0" && button.Text == "0") // если текст в  главной строке "0" и нажатая кнопка 0
                        break; // прекращаем работу кейсов

                    if (secondaryLabel.Text != "" && secondaryLabel.Text[secondaryLabel.Text.Length - 2] == '=') // если последний символ во втророй строке это знак равно
                        secondaryLabel.Text = ""; // то стераем всё в ней.

                    if (numInMainTextBox == false) // если числа в текстБоксе нету
                        mainTextBox.Text = button.Text; // записываем число в текстБокс которое написано на нажатой кнопке
                    else
                        mainTextBox.Text += button.Text; // иначе не изменяем текст в текстБокс, а добавляем
                    numInMainTextBox = true; // в переменную записываем значение истиное, т.к. число там теперь есть.
                    break;

                case ",": // ставит запятую чтобы сделать дробное число
                    if (!mainTextBox.Text.Contains(',')) // если в строке нету комы
                    {
                        mainTextBox.Text += ","; // добавляем запятую в текстБокс
                        numInMainTextBox = true; // и текст там теперь есть.
                    }
                    break;

                case "+/-": // переводит число в его негативный вариант. Если число положительное то переводит его в отрицательное и наоборот.
                    if (mainTextBox.Text != "0")
                    {
                        if (mainTextBox.Text[0] == '-') // если в главной строке в её начале есть символ "-"
                            mainTextBox.Text = mainTextBox.Text.Remove(0, 1); // мы его убераем
                        else
                            mainTextBox.Text = mainTextBox.Text.Insert(0, "-"); // иниче, записываем в начало символ "-"
                    }
                    break;

                case "1/x": // делит 1 на число записаное в главной строке
                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] != ',') // если последний символ в главной строке не ","
                        mainTextBox.Text = Convert.ToString(1 / Convert.ToDouble(mainTextBox.Text)); // то записываем в главную строку один делёное на число в главной строке
                    else // иначе
                        mainTextBox.Text = Convert.ToString(1 / Convert.ToDouble(mainTextBox.Text.Remove(mainTextBox.Text.Length - 1))); // сперва удаляем последний символ в главной строке, а потом делаем то что выше.
                    break;

                case "×": // операторы
                case "÷":
                case "+":
                case "-":
                case "^":
                    char[] operations = { '×', '÷', '+', '-', '^' }; // массив операторов

                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] == ',') // если последний символ в строке ","
                        mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1); // удаляем его

                    if (numInMainTextBox == false && secondaryLabel.Text != "" && secondaryLabel.Text[secondaryLabel.Text.Length - 2] == '=')
                    {
                        secondaryLabel.Text = $"{mainTextBox.Text} {button.Text} ";
                    }
                    else if (numInMainTextBox == false && secondaryLabel.Text != "") // если числа в главной строке нету И во второй строке не пусто
                    {
                        foreach (var operation in operations) // проходимся по массиву
                            if (operation == secondaryLabel.Text[secondaryLabel.Text.Length - 2]) // если предпоследний символ во второй строке это тот что в массиве
                            {
                                secondaryLabel.Text = secondaryLabel.Text.Remove(secondaryLabel.Text.Length - 3); // мы его удаляем
                                secondaryLabel.Text += $" {button.Text} "; // и добавляем свой что написан на нажатой кнопке
                                break; // прекращаем выполнение цикла
                            }
                    }
                    else // иначе(если число в главной строке есть)
                        secondaryLabel.Text += $"{mainTextBox.Text} {button.Text} "; // добавляем к второй строке значение из главной + текст на нажатой кнопке(оператор)

                    int operationsInSecondaryLabel = 0; // сколько операторов в строке
                    foreach (var operation in operations) // проходимся по каждому оператору в массиве операторов
                        foreach (var symbol in secondaryLabel.Text) // проходимся по каждому символу во второй строке
                            if (operation == symbol) // если оператор в массиве равняется символу в строке
                                operationsInSecondaryLabel++; // +1 к переменной которая говорит сколько операторов в строке

                    if (operationsInSecondaryLabel > 1) // если в строке больше одного оператора
                        mainTextBox.Text = Calculate(secondaryLabel.Text.Remove(secondaryLabel.Text.Length - 3)).ToString(); // используем метод Calculate и передаем в него строку без последнего оператора. А рузультат записываем в главную строку

                    numInMainTextBox = false; // говорим что в главной строке нету числа.
                    break;

                case "=":
                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] == ',') // если последний символ в строке ","
                        mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1); // удаляем его

                    string input = secondaryLabel.Text + mainTextBox.Text; // строка котроая будет отправленя в метод Calculate(input)
                    mainTextBox.Text = Calculate(input).ToString(); // Записываем результат в главную строку
                    secondaryLabel.Text = input + " = "; // во вторую строку записываем нашеё выражение и в конце знак равно.

                    numInMainTextBox = false; // говорим что в главной строке нету числа.

                    string save = richTextBox1.Text;

                    richTextBox1.Text = secondaryLabel.Text + mainTextBox.Text + "\n" + "\n";
                    richTextBox1.Text += save;

                    break;

                case "C":
                    mainTextBox.Text = "0";
                    secondaryLabel.Text = "";
                    numInMainTextBox = false;
                    break;

                case "CE":
                    if (mainTextBox.Text.Length > 2 && mainTextBox.Text[mainTextBox.Text.Length - 2] == '=')
                        goto case "C";
                    else
                    {
                        mainTextBox.Text = "0";
                        numInMainTextBox = false;
                    }
                    break;

                case "⌫":
                    if (mainTextBox.Text != "0")
                        mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1);
                    break;

                case "√":
                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] != ',') // если последний символ в главной строке не ","
                        mainTextBox.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(mainTextBox.Text)));
                    else // иначе
                        mainTextBox.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(mainTextBox.Text.Remove(mainTextBox.Text.Length - 1))));
                    break;

                case "%":
                    double result;
                    char oper;

                    if (mainTextBox.Text[mainTextBox.Text.Length - 1] == ',') // если последний символ в главной строке не ","
                        mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1);

                    oper = secondaryLabel.Text[secondaryLabel.Text.Length - 2]; // последний оператор в строке

                    result = Calculate(secondaryLabel.Text.Remove(secondaryLabel.Text.Length - 3));

                    if (oper == '-' || oper == '+')
                        mainTextBox.Text = Convert.ToString(Convert.ToDouble(mainTextBox.Text) * result / 100);
                    else if (oper == '×' || oper == '÷' || oper == '^')
                        mainTextBox.Text = Convert.ToString(Convert.ToDouble(mainTextBox.Text) / 100);

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

        private double Calculate(string input) // input - строка с которой будут проводитя манипуляции
        {
            double num1, num2; // числа с которыми будут проводится операции
            double result = 0; // результат
            string[] operationsMassive = { "+", "-", "×", "÷", "^" }; // массив во всеми операторами

            List<string> operationsList = new List<string>(input.Split(' ')); // разделяем в этих местах строку и делаем из неё список операторов
            List<string> numbersList = new List<string>(input.Split(' ', '+', '×', '÷', '^')); // разделяем в этих местах строку и делаем из неё список чисел

            numbersList.RemoveAll(x => x == "-"); // убераем все знаки минуса, котрые отдельно от числа. Если бы я указал разделять скроку по минусу, то отрецательное число переделывалось в положительное, а это не надо
            numbersList.RemoveAll(x => x == ""); // убераем пустые элементы в списке чисел

            for (int i = 0; i < operationsList.Count; i++)
                if (operationsList[i] != "+" || operationsList[i] != "-" || operationsList[i] != "×" || operationsList[i] != "÷" || operationsList[i] != "^")
                    operationsList.RemoveAt(i);

            if (numbersList.Count == 1)
                return Convert.ToDouble(numbersList[0]);

            if (numbersList.Count > 1) // если элементов в списке чисел больше одного
            {
                while (operationsList.IndexOf("^") != -1) // пока в списке операторов есть символ возведения в степень
                {
                    int indexOfOpeation = operationsList.IndexOf("^"); // индекс нахождения символа возведения в степень в списке операторов
                    int indexOfNum1 = indexOfOpeation; // индекс нахождения первого числа
                    int indexOfNum2 = indexOfOpeation + 1; // индекс нахождения второго числа
                    num1 = Convert.ToDouble(numbersList[indexOfNum1]); // первое число
                    num2 = Convert.ToDouble(numbersList[indexOfNum2]); // второе число
                    result = Math.Pow(num1, num2); // результат (первое число в степени второго числа)

                    numbersList.RemoveAt(indexOfNum2); // убираем из списка чисел num2 (num2 - второе число)
                    numbersList.RemoveAt(indexOfNum1); // убираем из списка чисел num1 (num1 - первое число)

                    operationsList.RemoveAt(indexOfOpeation); // убераем из списка операторов оператор который мы недавно использовали

                    numbersList.Insert(indexOfNum1, result.ToString()); // добавляем на место тех двух чисел результат из них
                }

                while (operationsList.IndexOf("×") != -1 || operationsList.IndexOf("÷") != -1) // пока в списке операторов есть знак умножения или знак деления...
                {
                    if ((operationsList.IndexOf("÷") > operationsList.IndexOf("×") && operationsList.IndexOf("×") != -1) || operationsList.IndexOf("÷") == -1) // если (знак умножения ближе к началу списка чем знак деления И
                    {                                                                                                                                   // знак умножения вообще есть в списке) ИЛИ знака деления в списке нету...
                        int indexOfOpeation = operationsList.IndexOf("×");
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
