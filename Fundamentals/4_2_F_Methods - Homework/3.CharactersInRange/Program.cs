using System;

namespace _3.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char inputOne = char.Parse(Console.ReadLine());
            char inputTwo = char.Parse(Console.ReadLine());

            PrintCharactersRange(inputOne, inputTwo);
        }

        private static void PrintCharactersRange(char inputOne, char inputTwo)
        {
            int start = Math.Min(inputOne, inputTwo);
            int end = Math.Max(inputOne, inputTwo);

            for (int i = start + 1; i < end; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
