using System;

namespace Problem_2 //Bin to DEC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a binary number: ");
            int number = int.Parse(Console.ReadLine());

            int decValue = 0;
            int baseValue = 1;
            int remainder;

            if (number == 0 || number == 0000)
            {
                Console.WriteLine("Decimal number: 0");

                return;
            }
            while (number > 0)
            {
                remainder = number % 10;
                decValue = decValue + remainder * baseValue;
                number /= 10;
                baseValue *= 2;
            }

            Console.WriteLine($"Decimal number: {decValue}");

        }
    }
}
