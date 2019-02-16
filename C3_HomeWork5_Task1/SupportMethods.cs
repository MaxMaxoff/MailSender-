using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_HomeWork5_Task1
{
    /// <summary>
    /// Part of SupportLibrary https://github.com/MaxMaxoff/SupportLibrary
    /// </summary>
    public class SupportMethods
    {

        /// <summary>
        /// Input value and convert them from Str to Int
        /// repeat until value become integer and can be converted
        /// </summary>
        /// <param name="message">string incoming from programm</param>
        /// <returns>integer value number</returns>
        public static int RequestIntValue(string message)
        {
            int number;

            Console.ForegroundColor = ConsoleColor.Red;
            do
            {
                Console.WriteLine(message);
            } while (!Int32.TryParse(Console.ReadLine(), out number));

            Console.ForegroundColor = ConsoleColor.Green;
            return number;
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

        public static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
