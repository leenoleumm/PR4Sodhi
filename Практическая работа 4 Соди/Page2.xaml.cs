using System;
using System.Windows;
using System.Windows.Controls;

namespace Практическая_работа_4_Соди
{
    /// <summary>
    /// страница 2 для расчёта функции l с выбором f(x)
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// обрабатывает нажатие кнопки вычислить
        /// </summary>
        /// <param name="sender">отправитель события</param>
        /// <param name="e">параметры события</param>
        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtX.Text, out double x) ||
                !double.TryParse(txtP.Text, out double p))
            {
                MessageBox.Show("Введите корректные числа");
                return;
            }

            double fx = GetFx(x);
            double result = CalculateL(fx, p, x);
            txtResult.Text = result.ToString("F6");
        }

        /// <summary>
        /// возвращает значение f(x) в зависимости от выбранного переключателя
        /// </summary>
        /// <param name="x">значение x</param>
        /// <returns>sh(x), x^2 или e^x</returns>
        private double GetFx(double x)
        {
            if (rbSh.IsChecked == true)
            {
                return Math.Sinh(x);
            }
            else if (rbX2.IsChecked == true)
            {
                return x * x;
            }
            else
            {
                return Math.Exp(x);
            }
        }

        /// <summary>
        /// вычисляет l по формуле
        /// </summary>
        /// <param name="fx">значение f(x)</param>
        /// <param name="p">значение p</param>
        /// <param name="x">значение x</param>
        /// <returns>результат вычисления l</returns>
        private double CalculateL(double fx, double p, double x)
        {
            double absP = Math.Abs(p);

            if (x > absP)
            {
                return 2 * Math.Pow(fx, 3) + 3 * p * p;
            }
            else if (3 < x && x < absP)
            {
                return Math.Abs(fx - p);
            }
            else
            {
                return Math.Pow(fx - p, 2);
            }
        }

        /// <summary>
        /// очищает все поля ввода и вывода, сбрасывает выбор на sh(x)
        /// </summary>
        /// <param name="sender">отправитель события</param>
        /// <param name="e">параметры события</param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtP.Clear();
            txtResult.Clear();
            rbSh.IsChecked = true;
        }
    }
}