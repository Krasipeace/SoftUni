using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Reverse_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(inputNumbers);

            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }          
        }
    }
}
