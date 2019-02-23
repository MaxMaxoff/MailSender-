using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SupportLibrary; // https://github.com/MaxMaxoff/SupportLibrary

/// <summary>
/// 1. Даны 2 двумерных матрицы. Размерность 100х100 каждая.
/// Напишите приложение, производящее параллельное умножение матриц.
/// Матрицы заполняются случайными целыми числами от 0 до 10.
/// </summary>
namespace C3_HomeWork6_Task1
{
    

    internal static class Program
    {
        /// <summary>
        /// Array of delimiters
        /// </summary>
        private static char[] delimiters = {',' , ';', ' '};

        private static Random _rnd = new Random();

        /// <summary>
        /// File Name, change it by yourself
        /// </summary>
        //private static string _fileNameA = @"D:\Projects\C#\matrix_a.csv";
        //private static string _fileNameB = @"D:\Projects\C#\matrix_b.csv";
        //private static string _fileNameOut = @"D:\Projects\C#\matrix_res.csv";
        //private static string _fileNameOutP = @"D:\Projects\C#\matrix_resP.csv";

        private static int[,] Matrix(int n)
        {
            int[,] _Matrix = new int[n,n];
            for (int i = 0; i<n;i++)
            for (int j = 0; j < n; j++)
                _Matrix[i, j] = _rnd.Next(0, 10);
            return _Matrix;
        }

        private static void Task1()
        {
            SupportMethods.PrepareConsoleForHomeTask("1. Даны 2 двумерных матрицы. Размерность 100х100 каждая.\r\n" +
                                                     "Напишите приложение, производящее параллельное умножение матриц.\r\n" +
                                                     "Матрицы заполняются случайными целыми числами от 0 до10.");

            //string _fileNameA = @"D:\Projects\C#\matrix_a.csv";
            //string _fileNameB = @"D:\Projects\C#\matrix_b.csv";
            //string _fileNameOut = @"D:\Projects\C#\matrix_res.csv";
            //string _fileNameOutP = @"D:\Projects\C#\matrix_resP.csv";

            //// read first matrix from file
            //Console.WriteLine($"Read {_fileNameA} file");
            //ReadFromFile(out var matrixA, _fileNameA);

            //// read second matrix from file
            //Console.WriteLine($"Read {_fileNameB} file");
            //ReadFromFile(out var matrixB, _fileNameB);

            int n = 200;

            int[,] matrixA = Matrix(n);
            int[,] matrixB = Matrix(n);
            DateTime starTime;
            DateTime endTime;

            starTime = DateTime.Now;
            Console.WriteLine("Calculating...");
            MultiplyMatrix(matrixA, matrixB, out var matrixOut);
            endTime = DateTime.Now;

            SupportMethods.Pause($"Calculating in {endTime - starTime}");

            //// write out result matrix
            //Console.WriteLine($"Write to {_fileNameOut} file");
            //WriteToFile(matrixOut, _fileNameOut);

            starTime = DateTime.Now;
            Console.WriteLine("Calculating in Parallel...");
            MultiplyMatrix(matrixA, matrixB, out var matrixOutP);
            endTime = DateTime.Now;

            SupportMethods.Pause($"Calculating in {endTime - starTime}");

            //// write out result matrix
            //Console.WriteLine($"Write to {_fileNameOutP} file");
            //WriteToFile(matrixOutP, _fileNameOutP);
        }

        /// <summary>
        /// Multiply Matrix
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <param name="B">Matrix B</param>
        /// <param name="R">Result Matrix</param>
        private static void MultiplyMatrix(int[,] A, int[,] B, out int[,] R)
        {
            R = new int[A.GetLength(0), A.GetLength(0)];

            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    for (int k = 0; k < B.GetLength(0); k++)
                        R[i,j] += A[i,k] * B[k,j];
        }

        /// <summary>
        /// Parallel Multiply Matrix
        /// </summary>
        /// <param name="A">Matrix A</param>
        /// <param name="B">Matrix B</param>
        /// <param name="R">Result Matrix</param>
        private static void ParallelMultiplyMatrix(int[,] A, int[,] B, out int[,] R)
        {
            R = new int[A.GetLength(0), A.GetLength(0)];

            var matrix = R;

            Parallel.For(0, A.GetLength(0), i =>
            {
                Parallel.For(0, A.GetLength(0), j =>
                {
                    matrix[i, j] = GetResultOfMultiply(i, j, A, B);
                });
            });
                
        }

        private static int GetResultOfMultiply(int i, int j, int[,] A, int[,] B)
        {
            int sum = 0;
            for (int k = 0; k < B.GetLength(0); k++)
                sum += A[i,k] * B[k,j];
            return sum;
        }

        /// <summary>
        /// Read matrix from file
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="_fileName"></param>
        private static void ReadFromFile(out int[,] matrix, string _fileName)
        {
            int n = TotalLines(_fileName);
            matrix = new int[n, n];
            using (StreamReader sr = new StreamReader(_fileName))
            {
                try
                {
                    int j = 0;
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            var number = sr.ReadLine().Split(delimiters);
                            for (int i = 0; i < number.Count(); i++)
                                Int32.TryParse(number[i], out matrix[i,j]);
                            j++;
                        }
                        catch (ArgumentNullException exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        catch (ArgumentException exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                finally
                {
                    if (sr != null) sr.Close();
                }                
            }
        }

        /// <summary>
        /// Write matrix to file
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="_fileName"></param>
        private static void WriteToFile(int[,] matrix, string _fileName)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                try
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(0) - 1; j++)
                            sw.Write(matrix[i, j].ToString() + ",");
                        sw.WriteLine(matrix[i, matrix.GetLength(0) - 1].ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    if (sw != null) sw.Close();
                }
            }
        }

        static int TotalLines(string _filePath)
        {
            using (StreamReader r = new StreamReader(_filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                if (r != null) r.Close();
                return i;
            }
        }
        

        private static void Task2()
        {

        }

        private static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Умножение матриц в один поток\n" +
                                                         "2 - Многопоточное умножение матриц\n" +
                                                         "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
