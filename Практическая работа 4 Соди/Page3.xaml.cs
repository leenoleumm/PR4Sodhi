using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace Практическая_работа_4_Соди
{
    /// <summary>
    /// страница 3 для табуляции и построения графика функции y(x)
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// обрабатывает нажатие кнопки вычислить
        /// выполняет табуляцию функции и строит график
        /// </summary>
        /// <param name="sender">отправитель события</param>
        /// <param name="e">параметры события</param>
        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtX0.Text, out double x0) ||
                !double.TryParse(txtXk.Text, out double xk) ||
                !double.TryParse(txtDx.Text, out double dx) ||
                !double.TryParse(txtB.Text, out double b))
            {
                MessageBox.Show("Введите корректные числа");
                return;
            }

            if (dx <= 0)
            {
                MessageBox.Show("Шаг dx должен быть больше 0");
                return;
            }

            if (x0 >= xk)
            {
                MessageBox.Show("x0 должен быть меньше xk");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("x\t\t\ty");
            sb.AppendLine("----------------------------------------");

            ChartValues<double> xValues = new ChartValues<double>();
            ChartValues<double> yValues = new ChartValues<double>();

            for (double x = x0; x <= xk + 0.0001; x += dx)
            {
                double y = CalculateY(x, b);
                sb.AppendLine($"{x:F6}\t\t{y:F6}");
                xValues.Add(x);
                yValues.Add(y);
            }

            txtResult.Text = sb.ToString();

            lineSeries.Values = yValues;
        }

        /// <summary>
        /// вычисляет y по формуле
        /// </summary>
        /// <param name="x">значение x</param>
        /// <param name="b">значение b</param>
        /// <returns>результат вычисления y или NaN при делении на ноль</returns>
        private double CalculateY(double x, double b)
        {
            double numerator = Math.Pow(Math.Abs(x - b), 2);
            double denominator = Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 2);

            if (denominator < 1e-9)
            {
                return double.NaN;
            }

            double term1 = numerator / denominator;
            double term2 = Math.Log(Math.Abs(x - b));

            return term1 + term2;
        }

        /// <summary>
        /// очищает все поля ввода и вывода, удаляет график
        /// </summary>
        /// <param name="sender">отправитель события</param>
        /// <param name="e">параметры события</param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX0.Clear();
            txtXk.Clear();
            txtDx.Clear();
            txtB.Clear();
            txtResult.Clear();
            lineSeries.Values = null;
        }
    }
}