using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Delete")
                {
                    int elementInNumbers = int.Parse(tokens[1]);
                    numbers.RemoveAll(elems => elems == elementInNumbers);
                }
                else if (action == "Insert")
                {
                    int elementInNumbers = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, elementInNumbers);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
