using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
              .Split()
              .Select(double.Parse)
              .ToArray();

            foreach (double number in numbers)
            {
                Console.WriteLine($"{number} => {(int)Math.Round(number, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
