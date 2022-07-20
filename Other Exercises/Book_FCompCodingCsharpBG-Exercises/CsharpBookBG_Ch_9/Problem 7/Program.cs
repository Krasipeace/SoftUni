using System;

namespace Problem_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int input = int.Parse(Console.ReadLine());
            
            int reversedNumber = 0;

            while (input != 0)
            {
                int remainder = input % 10;
                reversedNumber = (reversedNumber * 10) + remainder;
                input /= 10;
            }

            Console.WriteLine($"Reversed number is: {reversedNumber}");
        }
    }
}
