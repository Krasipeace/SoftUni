using System;

namespace Problem_12 //task 14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string[] text = Console.ReadLine().Split();
            int length = text.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                Console.Write($"{text[i]} ");
            }
        }
    }
}
