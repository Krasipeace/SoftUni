using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();

            Func<List<int>, List<int>> add = list => list.Select(number => number += 1).ToList();
            Func<List<int>, List<int>> multiply = list => list.Select(number => number *= 2).ToList();
            Func<List<int>, List<int>> subtract = list => list.Select(number => number -= 1).ToList();

            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
