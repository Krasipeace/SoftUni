using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                       .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(num => int.Parse(num)) 
                       .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}