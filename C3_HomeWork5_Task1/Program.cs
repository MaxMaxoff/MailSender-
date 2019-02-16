using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// <summary>
// GeekBrains C#3, HomeWork5, Task 1
// 1. Написать приложение, считающее в раздельных потоках:
// a. факториал числа N, которое вводится с клавиатуру;
// b. сумму целых чисел до N, которое также вводится с клавиатуры.
// </summary>
namespace C3_HomeWork5_Task1
{
    static class Program
    {

        private static ulong _fac;
        private static long _sum;

        /// <summary>
        /// Factorial
        /// </summary>
        /// <param name="parameter">Should be Int</param>
        /// <returns>Ulong Factorial</returns>
        static void Factorial(ulong n)
        {
            _fac = 1;
            
            for (ulong i = 2; i < n; _fac *= (ulong) i++)
                Console.WriteLine($"Считаю факториал, текущее значение:{_fac}");
        }


        static void Sum(int n)
        {
            _sum = 0;

            for (int i = 1; i <= n; _sum += i++)
                Console.WriteLine($"Считаю сумму, текущее значение:{_sum}");
        }

        static void Main(string[] args)
        {
            #region Input phase

            SupportMethods.PrepareConsoleForHomeTask("GeekBrains C#3, HomeWork5, Task 1\r\n" +
                                                     "1.Написать приложение, считающее в раздельных потоках:\r\n" +
                                                     "a.факториал числа N, которое вводится с клавиатуру;\r\n" +
                                                     "b.сумму целых чисел до N, которое также вводится с клавиатуры.");
            int n = SupportMethods.RequestIntValue("Введите N:");
            
            // Withoud new request for positive value, just convert current to positive
            n = Math.Abs(n);

            #endregion

            #region factorial

            var threadFac = new Thread(() => Factorial((ulong)n))
            {
                Priority = ThreadPriority.BelowNormal,
                IsBackground = true
            };
            threadFac.Start();

            #endregion
            
            #region Sum

            var threadSum = new Thread(() => Sum(n))
            {
                Priority = ThreadPriority.BelowNormal,
                IsBackground = true
            };
            threadSum.Start();

            #endregion

            threadFac.Join();
            threadSum.Join();

            #region Output phase

            Console.WriteLine($"Факториал числа {n} равен {_fac}");
            SupportMethods.Pause($"Сумма чисел от 1 до {n} равна {_sum}");

            #endregion
        }
    }
}
