using System;
using System.Collections.Generic;

namespace _2._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            input.ForEach(delegate (string name)
            {
                Console.WriteLine($"Sir {name}");
            });
        }
    }
}
