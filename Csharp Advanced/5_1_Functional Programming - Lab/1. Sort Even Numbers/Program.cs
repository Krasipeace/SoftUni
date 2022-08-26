using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(num => int.Parse(num))
                                   .Where(num => num % 2 == 0)
                                   .OrderBy(num => num)
                                   .ToArray();

            string result = string.Join(", ", numbers);
            Console.WriteLine(result);
        }
    }
}