using System;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var reverse = input.ToCharArray();
            Array.Reverse(reverse);
            Console.WriteLine(reverse);
        }
    }
}
