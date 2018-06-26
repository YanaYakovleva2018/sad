using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace Lab08
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Значение предыдущего текста для замены в случае неправильного ввода
        /// </summary>
        string prevText = "0";
        /// <summary>
        /// Обьект класса, эмулирующего калькулятор
        /// </summary>
        Calc Device = new Calc();
        /// <summary>
        /// Хранение выбранной операции
        /// </summary>
        int operation = 0;
        /// <summary>
        /// Флаг для корректного отображения результата
        /// </summary>
        bool resout = false;
        public MainWindow()
        {
            InitializeComponent();
            InOut.TextChanged += InOut_TextChanged;
            InOut_TextChanged(null,null);
        }
        /// <summary>
        /// Обработчик изменения текста в окне ввода операндов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InOut_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Error.Text = "";
            string pattern = @"^[\+-]{0,1}[0-9]*(\d[.]){0,1}[0-9]{0,5}$";
            string newText = InOut.Text;
            if (resout)
            {
                resout = false;
                prevText = newText;
                return;
            }
            if (Regex.IsMatch(newText, pattern))
            {
                if (newText != "" && newText != "-" && newText != "+")
                {
                    newText = newText.Replace('.',',');
                    double op = Convert.ToDouble(newText);
                    if (op > -2000000 && op < 4000000)
                    {
                        prevText = newText.Replace(',','.') ;
                    }
                    else
                    {
                        InOut.Text = prevText;
                        InOut.Select(prevText.Length, 0);
                        Error.Text = "Выход за границы от -2 000 000 до 4 000 000 ";
                    }
                }
                else
                {
                    prevText = newText;
                }
            }
            else 
            {
              
                    InOut.Text = prevText;
                    InOut.Select(prevText.Length, 0);
               
            }
        }
        /// <summary>
        /// Обработчик выбора сложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (InOut.Text != "")
            {
                Device.st_op1 = InOut.Text;
                operation = 1;
                History.Content = Device.st_op1 + " +";
                InOut.Text = "0";
                prevText = "0";
                
            }
            else
            {
                Error.Text = "Нельзя вводить пустой операнд!";
            }
            InOut.Focus();
            InOut.Select(prevText.Length, 0);
        }
        /// <summary>
        /// Обработчик выбора вычитания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            if (InOut.Text != "")
            {
                Device.st_op1 = InOut.Text;
                operation = 2;
                History.Content = Device.st_op1 + " -";
                InOut.Text = "0";
                prevText = "0";
            }
            else
            {
                Error.Text = "Нельзя вводить пустой операнд!";
            }
            InOut.Focus();
            InOut.Select(prevText.Length, 0);
        }
        /// <summary>
        /// Обработчик выбора умножения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mult_Click(object sender, RoutedEventArgs e)
        {
            if (InOut.Text != "")
            {
                Device.st_op1 = InOut.Text;
                operation = 3;
                History.Content = Device.st_op1 + " *";
                InOut.Text = "0";
                prevText = "0";
            }
            else
            {
                Error.Text = "Нельзя вводить пустой операнд!";
            }
            InOut.Focus();
            InOut.Select(prevText.Length, 0);
        }
        /// <summary>
        /// Обработчик выбора деления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Div_Click(object sender, RoutedEventArgs e)
        {
            if (InOut.Text != "")
            {
                Device.st_op1 = InOut.Text;
                operation = 4;
                History.Content = Device.st_op1 + " /";
                InOut.Text = "0";
                prevText = "0";
            }
            else
            {
                Error.Text = "Нельзя вводить пустой операнд!";
            }
            InOut.Focus();
            InOut.Select(prevText.Length, 0);
        }
        /// <summary>
        /// Обработчик выбора операции взятия корня
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Squre_Click(object sender, RoutedEventArgs e)
        {
            History.Content = "";
            if (InOut.Text == "")
            {
                Error.Text = "Нельзя вводить пустой операнд";
                return;
            }
            Device.st_op1 = InOut.Text;
            if (Device.SquareRoot())
            {
                string tmp = Device.result.ToString("G4").Replace(',', '.');
                InOut.Text = tmp;
            }
            else
            {
                Error.Text = "Попытка взятия корня из отрицательного!";
            }
        }
        /// <summary>
        /// Обработчик выбора операции взятия обратного к операнду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rev_Click(object sender, RoutedEventArgs e)
        {
            History.Content = "";
            if (InOut.Text == "")
            {
                Error.Text = "Нельзя вводить пустой операнд";
                return;
            }
            Device.st_op1 = InOut.Text;
            if (Device.Reverse())
            {
                string tmp = Device.result.ToString("G4").Replace(',', '.');
                InOut.Text = tmp;
            }
            else
            {
                Error.Text = "Попытка деления на ноль!!!";
            }
        }
        /// <summary>
        /// Обработчик выбора косинуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            History.Content = "";
            if (InOut.Text == "")
            {
                Error.Text = "Нельзя вводить пустой операнд";
                return;
            }
            Device.st_op1 = InOut.Text;
            Device.Cosinus();
            string tmp = Device.result.ToString("G4").Replace(',', '.');
            InOut.Text = tmp;
        }
        /// <summary>
        /// Обработчик выбора получения результата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Res_Click(object sender, RoutedEventArgs e)
        {
            if (InOut.Text == "")
            {
                Error.Text = "Нельзя вводить пустой операнд";
                return;
            }
            Device.st_op2 = InOut.Text;
            switch (operation)
            {
                case 0:
                    {
                        Error.Text = "Выберите операцию!!"; break;
                    }
                case 1:
                    {
                        Device.Add();
                        operation = 0;
                        History.Content = (string)History.Content + Device.st_op2;
                        string tmp = Device.result.ToString().Replace(',', '.');
                        resout = true;
                        InOut.Text = tmp;
                    } break;
                case 2:
                    {
                        Device.Sub();
                        operation = 0;
                        History.Content = (string)History.Content + Device.st_op2;
                        string tmp = Device.result.ToString().Replace(',', '.');
                        resout = true;
                        InOut.Text = tmp;
                    }break;
                case 3:
                    {
                        Device.Mul();
                        operation = 0;
                        History.Content = (string)History.Content + Device.st_op2;
                        string tmp = Device.result.ToString().Replace(',', '.');
                        resout = true;
                        InOut.Text = tmp;
                    }break;
                case 4:
                    {
                        operation = 0;
                        if (Device.Div())
                        {
                            string tmp = Device.result.ToString().Replace(',', '.');
                            History.Content = (string)History.Content + Device.st_op2;
                            resout = true;
                            InOut.Text = tmp;
                        }
                        else
                        {
                            Error.Text = "Попытка деления на ноль!!!";
                            operation = 4;
                            break;
                        }
                    }break;
            }
        }
        /// <summary>
        /// Обработчик выбора закрытия окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Обработчик выбора очистки поля ввода/вывода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Error.Text = "";
            History.Content = "";
            prevText = "0";
            operation = 0;
            InOut.Text = "0";
        }

        private void InOut_PreviewKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void InOut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
