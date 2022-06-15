using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            for (int checkNumber = 1; checkNumber <= range; checkNumber++)
            {
                if (isSumDivisionByEight (checkNumber) && isThereOddDigit (checkNumber))
                {
                    Console.WriteLine(checkNumber);
                }
            }
        }

        private static bool isThereOddDigit(int topNumber)
        {
            while (topNumber > 0)
            {
                if (topNumber % 10 % 2 != 0)
                {
                    return true;
                }
                topNumber /= 10;
            }
            return false;
        }

        private static bool isSumDivisionByEight(int topNumber)
        {
            int sumDigits = 0;

            while (topNumber > 0)
            {
                sumDigits += topNumber % 10;
                topNumber /= 10;
            }

            if (sumDigits % 8 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
