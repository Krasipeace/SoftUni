using System;
using System.Linq;

namespace _3._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            numbers.OrderByDescending(x => x).Take(3).ToList().ForEach(x => Console.Write($"{x} "));           
        }
    }
}
