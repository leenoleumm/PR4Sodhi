using System;
using System.Windows;
using System.Windows.Controls;

namespace Практическая_работа_4_Соди
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

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

        private double CalculatePsi(double x, double y, double z)
        {
            double term1 = Math.Abs(Math.Pow(x, y / x) - Math.Pow(y, 1.0 / 3.0));
            double denominator = 1 + Math.Pow(y - x, 2);
            double term2 = (y - x) * (Math.Cos(y) - z / (y - x)) / denominator;
            return term1 + term2;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            txtResult.Clear();
        }
    }
}