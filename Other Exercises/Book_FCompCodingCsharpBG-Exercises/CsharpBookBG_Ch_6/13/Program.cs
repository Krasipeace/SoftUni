using System;

namespace zad13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //13.Програма, която преобразува дадено число от двоична в десетична бройна система.

            Console.Write("Enter binary: ");
            int binaryNumber = int.Parse(Console.ReadLine());

            int decimalValue = 0;
            int value = 1;                                     //2^0 

            while (binaryNumber > 0)
            {
                int reminder = binaryNumber % 10;
                binaryNumber = binaryNumber / 10;
                decimalValue += reminder * value;
                value *= 2;
            }

            Console.Write($"Decimal: {decimalValue}");
        }
    }
}
