using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C3_HomeWork5_Task2
{
    class Program
    {
        /// <summary>
        /// Array of delimiters
        /// </summary>
        private static char[] delimiters = { ',', ';'};

        /// <summary>
        /// File Name, change it by yourself
        /// </summary>
        private static string _fileName = @"D:\Projects\C#\students_4.csv";
        private static string _fileNameOut = @"D:\Projects\C#\students_4.txt";

        private static Queue<string[]> database = new Queue<string[]>();
        
        private static readonly object __SyncRoot = new object();

        static void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(_fileName))
            {
                try
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            lock (__SyncRoot)
                            {
                                string[] student = sr.ReadLine().Split(delimiters);
                                database.Enqueue(student);
                            }
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

        static void WriteToFile()
        {
            bool newData = true;
            using (StreamWriter sw = new StreamWriter(_fileNameOut))
            {
                try
                {
                    while (newData)
                    {
                        while (database.Count > 0)
                        {
                            try
                            {
                                lock (__SyncRoot)
                                {
                                    string[] student = database.Dequeue();
                                    for (int i = 0; i < student.Length; i++)
                                        sw.WriteLine(student[i]);
                                }
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

                        newData = false;
                        Thread.Sleep(2000);
                        if (database.Count > 0) newData = true;
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


        static void Main(string[] args)
        {
            database.Clear();

            Console.WriteLine("Start!");
            
            var threadReadFromFile = new Thread(ReadFromFile)
            {
                Priority = ThreadPriority.BelowNormal,
                IsBackground = true
            };
            threadReadFromFile.Start();
            
            var threadWriteToFile = new Thread(WriteToFile)
            {
                Priority = ThreadPriority.BelowNormal,
                IsBackground = true
            };
            threadWriteToFile.Start();

            threadReadFromFile.Join();
            threadWriteToFile.Join();
            
            Console.WriteLine("Write Complete!");
            Console.ReadKey();
        }

        int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                if (r != null) r.Close();
                return i;
            }
        }
    }
}
