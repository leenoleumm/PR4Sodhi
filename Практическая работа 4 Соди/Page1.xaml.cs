using System;
using System.Windows;
using System.Windows.Controls;

namespace Практическая_работа_4_Соди
{
    /// <summary>
    /// страница 1 для расчёта функции psi
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
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
                !double.TryParse(txtY.Text, out double y) ||
                !double.TryParse(txtZ.Text, out double z))
            {
                MessageBox.Show("Введите корректные числа");
                return;
            }

            if (Math.Abs(y - x) < 1e-9)
            {
                MessageBox.Show("y - x не может быть равно 0");
                return;
            }

            double psi = CalculatePsi(x, y, z);
            txtResult.Text = psi.ToString("F6");
        }

        /// <summary>
        /// вычисляет psi по формуле
        /// </summary>
        /// <param name="x">значение x</param>
        /// <param name="y">значение y</param>
        /// <param name="z">значение z</param>
        /// <returns>результат вычисления psi</returns>
        private double CalculatePsi(double x, double y, double z)
        {
            double term1 = Math.Abs(Math.Pow(x, y / x) - Math.Pow(y, 1.0 / 3.0));
            double denominator = 1 + Math.Pow(y - x, 2);
            double term2 = (y - x) * (Math.Cos(y) - z / (y - x)) / denominator;
            return term1 + term2;
        }

        /// <summary>
        /// очищает все поля ввода и вывода
        /// </summary>
        /// <param name="sender">отправитель события</param>
        /// <param name="e">параметры события</param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            txtResult.Clear();
        }
    }
}