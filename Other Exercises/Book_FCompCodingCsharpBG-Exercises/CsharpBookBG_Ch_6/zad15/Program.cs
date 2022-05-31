using System;

namespace zad15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //15.Програма, която преобразува дадено число от шестнайсе­тична в десетична бройна система.

            Console.Write("Enter hex: ");
            string hex = Console.ReadLine();
            int len = hex.Length;

            // 16^0
            int base1 = 1;
            int decNum = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                if (hex[i] >= '0' && hex[i] <= '9')
                {
                    decNum += (hex[i] - 48) * base1;

                    // incrementing base1 by power
                    base1 = base1 * 16;
                }

                else if (hex[i] >= 'A' && hex[i] <= 'F')
                {
                    decNum += (hex[i] - 55) * base1;

                    // incrementing base1 by power
                    base1 = base1 * 16;
                }
            }
            Console.WriteLine($"Decimal: {decNum}");
        }
    }
}
