using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if(command == "end")
                {
                    break;
                }

                string[] tokens = command.Split();
                string action = tokens[0];
                // int indexOne = int.Parse(tokens[1]);
                // int indexTwo = int.Parse(tokens[2]);

                switch (action)
                {
                    case "swap": SwapIndex(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);
                        break;
                    case "multiply": MultiplyIndex(int.Parse(tokens[1]), int.Parse(tokens[2]), numbers);
                        break;
                    case "decrease": DecreaseAll(numbers);
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void DecreaseAll(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 1;
            }
        }

        private static void MultiplyIndex(int indexOne, int indexTwo, List<int> numbers)
        {
            numbers[indexOne] = numbers[indexOne] * numbers[indexTwo];
        }

        private static void SwapIndex(int indexOne, int indexTwo, List<int> numbers)
        {
            int savedValue = numbers[indexOne];
            
            numbers[indexOne] = numbers[indexTwo];
            numbers[indexTwo] = savedValue;
        }
    }
}
