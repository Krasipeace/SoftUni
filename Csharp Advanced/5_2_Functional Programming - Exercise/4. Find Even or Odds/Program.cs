using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Even_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(r => int.Parse(r)).ToArray();
            int start = range[0];
            int end = range[1];
            string command = Console.ReadLine();

            List<int> numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Func<List<int>, List<int>> even = list => list.Where(number => number % 2 == 0).ToList();
            Func<List<int>, List<int>> odd = list => list.Where(number => number % 2 != 0).ToList();

            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            switch (command)
            {
                case "even":
                    numbers = even(numbers);
                    break;
                case "odd":
                    numbers = odd(numbers);
                    break;
            }
            print(numbers);
        }
    }
}
