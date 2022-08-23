using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(input);

            string command = Console.ReadLine().ToLower();
            while (true)
            {
                if (command == "end")
                {
                    break;
                }
                string[] tokens = command.Split();
                string action = tokens[0].ToLower();

                switch (action)
                {
                    case "add":
                        int numberOne = int.Parse(tokens[1]);
                        int numberTwo = int.Parse(tokens[2]);
                        numbers.Push(numberOne);
                        numbers.Push(numberTwo);
                        break;
                    case "remove":
                        int number = int.Parse(tokens[1]);
                        if (numbers.Count >= number)
                        {
                            for (int i = 0; i < number; i++)
                            {
                                numbers.Pop();
                            }                           
                        }
                        break;
                }

                command = Console.ReadLine().ToLower();
            }

            int sum = numbers.ToArray().Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}