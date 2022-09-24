using System;
using System.Collections.Generic;

namespace _1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            input.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });
        }
    }
}
