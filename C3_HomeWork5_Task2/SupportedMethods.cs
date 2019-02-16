using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_HomeWork5_Task2
{
    public class SupportMethods
    {
        /// <summary>
        /// Return string
        /// </summary>
        /// <param name="message">string incoming from programm</param>
        /// <returns>string str</returns>
        public static string RequestString(string message)
        {
            string str;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            str = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            return str;
        }

        /// <summary>
        /// Just clear and change font color
        /// Also write message
        /// </summary>
        /// <param name="message">string incoming from programm</param>
        public static void PrepareConsoleForHomeTask(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        public static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static void Print(string message, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
        }

        public static void Print(string message, int x, int y, string color)
        {
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }

            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Green;
        }

    }
}
