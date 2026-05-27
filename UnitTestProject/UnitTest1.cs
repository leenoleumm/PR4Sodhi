using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    /// <summary>
    /// класс с модульными тестами для проверки математических функций
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private const double Tolerance = 0.000001;

        /// <summary>
        /// тренировочный тест для проверки работы Assert
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }

        /// <summary>
        /// тест для функции из страницы 1
        /// проверяет вычисление при x=2, y=3, z=1
        /// ожидаемый результат 0,391181
        /// </summary>
        [TestMethod]
        public void TestFunctionPsi()
        {
            double x = 2;
            double y = 3;
            double z = 1;
            double expected = 0.391181;

            double actual = CalculatePsi(x, y, z);

            Assert.AreEqual(expected, actual, Tolerance);
        }

        /// <summary>
        /// тест для функции из страницы 2
        /// проверяет условие x > |p| при f(x)=sh(x)
        /// ожидаемый результат 817155,038302
        /// </summary>
        [TestMethod]
        public void TestFunctionL()
        {
            double x = 5;
            double p = 2;
            double fx = Math.Sinh(x);
            double expected = 817155.038302;

            double actual = CalculateL(fx, p, x);

            Assert.AreEqual(expected, actual, Tolerance);
        }

        /// <summary>
        /// тест для функции из страницы 3
        /// проверяет вычисление при x=1, b=2
        /// ожидаемый результат 0,020408
        /// </summary>
        [TestMethod]
        public void TestFunctionY()
        {
            double x = 1;
            double b = 2;
            double expected = 0.020408;

            double actual = CalculateY(x, b);

            Assert.AreEqual(expected, actual, Tolerance);
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
        /// вычисляет y по формуле 
        /// </summary>
        /// <param name="x">значение x</param>
        /// <param name="b">значение b</param>
        /// <returns>результат вычисления y</returns>
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
    }
}