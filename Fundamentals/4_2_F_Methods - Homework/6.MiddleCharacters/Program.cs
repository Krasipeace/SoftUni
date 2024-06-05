using System;

namespace _6.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChars(input);
        }

        private static void PrintMiddleChars(string input)
        {
            if (input.Length % 2 == 0)
            {
                Console.Write(input[(input.Length / 2) - 1]);
                Console.WriteLine(input[input.Length / 2]);
            }
            else
            {
                Console.WriteLine(input[input.Length / 2]);
            }
        }
    }
}
