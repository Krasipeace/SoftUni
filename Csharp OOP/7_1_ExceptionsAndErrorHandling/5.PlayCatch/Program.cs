using System;
using System.Collections.Generic;
using System.Linq;

//When you catch 3 exceptions – stop the input and print the elements of the array separated with ", ".
namespace _5.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            int counter = 0;
            while (counter < 3)
            {
                string[] commands = Console.ReadLine().Split();
                string action = commands[0];

                try
                {
                    switch (action)
                    {
                        case "Show":
                            ShowElement(numbers, commands);
                            break;
                        case "Replace":
                            ReplaceElement(numbers, commands);
                            break;
                        case "Print":
                            PrintList(numbers, commands);
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    counter++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    counter++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void ShowElement(List<int> numbers, string[] commands)
        {
            int index = int.Parse(commands[1]);
            Console.WriteLine(numbers[index]);
        }

        private static void ReplaceElement(List<int> numbers, string[] commands)
        {
            int index = int.Parse(commands[1]);
            int element = int.Parse(commands[2]);
            numbers.RemoveAt(index);
            numbers.Insert(index, element);
        }

        private static void PrintList(List<int> numbers, string[] commands)
        {
            int start = int.Parse(commands[1]);
            int end = int.Parse(commands[2]);
            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                list.Add(numbers[i]);
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}


