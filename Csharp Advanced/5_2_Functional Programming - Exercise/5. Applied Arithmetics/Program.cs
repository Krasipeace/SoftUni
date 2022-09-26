using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();
            string command = Console.ReadLine();
            List<int> output = new List<int>();
            

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        output += inputNumbers.Select(n => n + 1).ToList();
                        break;
                    case "multiply":
                        output = inputNumbers.Select(n => n * 2).ToList();
                        break;
                    case "subtract":
                        output = inputNumbers.Select(n => n - 1).ToList();
                        break;
                    case "print":
                        foreach (int num in output)
                        {
                            Console.Write($"{num} ");
                        }
                        Console.WriteLine();
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
