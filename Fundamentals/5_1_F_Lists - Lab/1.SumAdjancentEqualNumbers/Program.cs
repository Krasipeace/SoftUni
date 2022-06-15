using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.SumAdjancentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int index = 0; index < numbers.Count - 1; index++)
            {
                int nextIndex = 0;

                if (index + 1 > numbers.Count - 1)
                {
                    break;
                }
                else
                {
                    nextIndex = index + 1;
                }

                if (numbers[index] == numbers[nextIndex])
                {
                    numbers[index] += numbers[nextIndex];
                    numbers.RemoveAt(nextIndex);
                    index = -1;
                }                 
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

    }
}
