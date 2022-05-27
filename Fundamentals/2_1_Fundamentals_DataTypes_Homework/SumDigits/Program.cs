using System;

namespace SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sumDigit = 0;
            
            do
            {
                sumDigit = sumDigit + (input % 10);
                input /= 10;
            }
            while (input > 0);

            Console.WriteLine(sumDigit);
        }
    }
}
