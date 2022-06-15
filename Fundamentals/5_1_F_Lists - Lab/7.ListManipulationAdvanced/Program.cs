using System;
using System.Linq;
using System.Collections.Generic;

namespace _7.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isItChanged = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        isItChanged = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        isItChanged = true;
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemove);
                        isItChanged = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        isItChanged = true;
                        break;
                    case "Contains":
                        Contains(numbers);
                        break;
                    case "PrintEven":
                        PrintEven(numbers);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;
                    case "GetSum":
                        PrintGetSum(numbers);
                        break;
                    case "Filter":
                        UseFilter(numbers);
                        break;
                }
            }

        }

        private static void UseFilter(List<int> numbers)
        {
            string command = Console.ReadLine();
            
            switch (command)
            {
                case "<":

                    break;
                case ">":
                    break;
                case "<=":
                    break;
                case ">=":
                    break;
            }

        }

        private static void PrintGetSum(List<int> numbers)
        {
            int sum = 0;
            sum += numbers.Sum();
            Console.WriteLine(sum);
        }

        private static void PrintOdd(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    List<int> arrayPrintOdd = new List<int>();
                    arrayPrintOdd.Add(numbers[i]);
                    Console.Write(string.Join(" ", arrayPrintOdd));
                }
            }
        }

        private static void PrintEven(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 != 0)
                {
                    List<int> arrayPrintEven = new List<int>();
                    arrayPrintEven.Add(numbers[i]);
                    Console.Write(string.Join(" ", arrayPrintEven));
                }
            }
        }

        private static void Contains(List<int> numbers)
        {
            int numberToCheck = int.Parse(Console.ReadLine());
            bool isContaining = numbers.Contains(numberToCheck);
            if (isContaining)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
    }
}
