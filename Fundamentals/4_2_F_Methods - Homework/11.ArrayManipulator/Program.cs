using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int givenIndex = int.Parse(command[1]);
                    array = ExchangeArray(array, givenIndex);
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    FindMinOrMax(array, command[0], command[1]);
                }
                else
                {
                    FindNumbers(array, command[0], int.Parse(command[1]), command[2]);
                }

                command = Console.ReadLine().Split();
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        private static int[] ExchangeArray(int[] array, int givenIndex)
        {
            if (givenIndex >= array.Length || givenIndex < 0)
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            int[] exchangeArray = new int[array.Length];
            int index = 0;
            
            for (int i = givenIndex + 1; i < array.Length; i++)
            {
                exchangeArray[index] = array[i];
                index++;
            }
            for (int i = 0; i <= givenIndex; i++)
            {
                exchangeArray[index] = array[i];
                index++;
            }
            return exchangeArray;
        }

        private static void FindMinOrMax(int[] array, string minOrMax, string evenOrOdd)
        {
            int index = -1;
            int minIndexNumber = int.MaxValue;
            int maxIndexNumber = int.MinValue;
            int resultEvenOrOdd = 1;

            if (evenOrOdd == "even")
            {
                resultEvenOrOdd = 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == resultEvenOrOdd)
                {
                    if (minOrMax == "min" && minIndexNumber >= array[i])
                    {
                        minIndexNumber = array[i];
                        index = i;
                    }
                    else if (minOrMax == "max" && maxIndexNumber <= array[i])
                    {
                        maxIndexNumber = array[i];
                        index = i;
                    }
                }
            }

            Console.WriteLine(index > -1 ? index.ToString() : "No matches");

        }

        private static void FindNumbers(int[] array, string position, int countNumbers, string evenOrOdd)
        {
            if (countNumbers > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (countNumbers == 0)
            {
                Console.WriteLine($"[]");
                return;
            }

            int resultEvenOrOdd = 1;
            if (evenOrOdd == "even")
            {
                resultEvenOrOdd = 0;
            }
            int counter = 0;

            List<int> numbers = new List<int>();

            if (position == "first")
            {
                foreach (int number in array)
                {
                    if (number % 2 == resultEvenOrOdd)
                    {
                        counter++;
                        numbers.Add(number);
                    }

                    if (counter == countNumbers)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == resultEvenOrOdd)
                    {
                        counter++;
                        numbers.Add(array[i]);
                    }

                    if (counter == countNumbers)
                    {
                        break;
                    }
                }
                numbers.Reverse();
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}
