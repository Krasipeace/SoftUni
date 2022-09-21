using System;
using System.Collections.Generic;

namespace _3._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int linesOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesOfInputs; i++)
            {
                string[] inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var unique in inputLine)
                {
                    elements.Add(unique);
                }
            }

            foreach (var element in elements)
            {
                Console.Write($"{element} ");
            }
        }
    }
}