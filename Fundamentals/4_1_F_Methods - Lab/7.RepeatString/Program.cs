using System;

namespace _7.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int repeatCounter = int.Parse(Console.ReadLine());

            RepeatString(inputString, repeatCounter);
        }

        private static string RepeatString(string inputString, int repeatCounter)
        {
            string result = string.Empty;

            for (int i = 0; i < repeatCounter; i++)
            {
                Console.Write($"{inputString}");
            }

            return result;
        }
    }
}
