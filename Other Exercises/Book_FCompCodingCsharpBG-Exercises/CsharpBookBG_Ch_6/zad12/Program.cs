using System;

namespace zad12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //12.Програма, която преобразува дадено число от десетична в двоична бройна система.

            Console.Write("Enter number: ");
            int decimalNumber = int.Parse(Console.ReadLine());

            int remainder = 0;
            string result = string.Empty;

            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            Console.WriteLine($"Binary: {result}");

        }
    }
}
