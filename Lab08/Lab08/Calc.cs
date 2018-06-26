using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    /// <summary>
    /// Класс эмулирующий работу калькулятора
    /// </summary>
    public class Calc
    {
        /// <summary>
        /// Переменная хранящая результат
        /// </summary>
        private double res;
        /// <summary>
        /// Переменные хранящие операнды
        /// </summary>
        private string s_op1, s_op2;
        /// <summary>
        /// Свойство для s_op1
        /// </summary>
        public string st_op1
        {
            set
            {
                s_op1 = value.Replace('.', ',');
                if (s_op1 == "+" || s_op1 == "-")
                    s_op1 = "0";
            }
            get
            {
                return s_op1;
            }
        }
        /// <summary>
        /// Свойство для s_op2
        /// </summary>
        public string st_op2
        {
            set
            {
                s_op2 = value.Replace('.', ',');
                if (s_op2 == "+" || s_op2 == "-")
                    s_op2 = "0";
            }
            get
            {
                return s_op2;
            }
        }
        /// <summary>
        /// Свойство для res
        /// </summary>
        public double result
        {
            get
            {
                return res;
            }
            set { }
        }
        /// <summary>
        /// Сложение операндов
        /// </summary>
        public void Add()
        {
            res = double.Parse(s_op1) + double.Parse(s_op2);
            res = Math.Round(res, 5);
        }
        /// <summary>
        /// Вычитание операндов
        /// </summary>
        public void Sub()
        {
            res = double.Parse(s_op1) - double.Parse(s_op2);
            res = Math.Round(res, 5);
        }
        /// <summary>
        /// Умножение операндов
        /// </summary>
        public void Mul()
        {
            res = double.Parse(s_op1) * double.Parse(s_op2);
            res = Math.Round(res, 5);
        }
        /// <summary>
        /// Деление с проверкой
        /// </summary>
        /// <returns>false - При делении на ноль</returns>
        public bool Div()
        {
            if (double.Parse(s_op2) == 0)
            {
                return false;
            }
            else
            {
                res = double.Parse(s_op1) / double.Parse(s_op2);
                res = Math.Round(res, 5);
                return true;
            }
        }
        /// <summary>
        /// Взятие квадратного корня с проверкой
        /// </summary>
        /// <returns>false - При отрицательном операнде</returns>
        public bool SquareRoot()
        {
            if (double.Parse(s_op1) >= 0)
            {
                res = Math.Pow(double.Parse(s_op1), 0.5);
                res = Math.Round(res, 5);
                return true;

            }
            else
                return false;
        }
        /// <summary>
        /// Взятие косинуса (В радианнах)
        /// </summary>
        public void Cosinus()
        {
            res = Math.Cos(double.Parse(s_op1));
            res = Math.Round(res, 5);
        }
        /// <summary>
        /// Получение числа обратного к данному
        /// </summary>
        /// <returns>false - При делении на ноль</returns>
        public bool Reverse()
        {
            if (double.Parse(s_op1) != 0)
            {
                res = 1 / double.Parse(s_op1);
                res = Math.Round(res, 5);
                return true;

            }
            else
                return false;
        }

    }
}


