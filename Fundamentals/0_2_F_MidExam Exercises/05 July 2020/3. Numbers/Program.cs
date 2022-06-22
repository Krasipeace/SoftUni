using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Numbers
{
    internal class Program      //90/100 in Judge... unknown possible error test #8
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

            double averageNumber = Math.Floor(numbers.Sum() / numbers.Count);
            if (numbers.Count < 5)
            {
                Console.WriteLine("No");

                return;
            }

            List<double> topNumbers = new List<double>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > averageNumber)
                {
                    topNumbers.Add(numbers[i]);
                }
            }
            topNumbers.Sort();
            topNumbers.Reverse();
            var topFive = topNumbers.Take(5);

            Console.WriteLine(string.Join(" ", topFive));
        }
    }
}
