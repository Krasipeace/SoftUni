using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersAsStrings = Console.ReadLine().Split('|').Reverse().ToList();
            List<int> numbers = new List<int>();

            foreach (var number in numbersAsStrings)
            {
                numbers.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
