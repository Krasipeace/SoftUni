using System;

namespace OddEvenPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = int.Parse(Console.ReadLine());
            double oddSum = 0.0;
            double evenSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= num; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddSum += number;
                    if (number < oddMin)
                    {
                        oddMin = number;
                    }
                    if (number > oddMax)
                    {
                        oddMax = number;
                    }
                }
                if (i % 2 == 0)
                {
                    evenSum += number;
                    if (number < evenMin)
                    {
                        evenMin = number;
                    }
                    if (number > evenMax)
                    {
                        evenMax = number;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }
            if (oddMax == double.MinValue)
            {
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenMin == double.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }
            if (evenMax == double.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
