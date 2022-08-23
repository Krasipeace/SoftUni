using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int>  counter = new Dictionary<double, int>();

            foreach (double item in numbers)
            {
                if (counter.ContainsKey(item))
                {
                    counter[item]++;
                }
                else
                {
                    counter[item] = 1;
                }
            }

            foreach (var kvp in counter)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
