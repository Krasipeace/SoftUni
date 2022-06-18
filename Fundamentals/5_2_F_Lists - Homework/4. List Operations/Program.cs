using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    int numberToAdd = int.Parse(tokens[1]);
                    numbers.Add(numberToAdd);
                }
                else if (tokens[0] == "Remove")
                {
                    int indexOfNumbers = int.Parse(tokens[1]);
                    if (indexOfNumbers > numbers.Count - 1 || indexOfNumbers < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(indexOfNumbers);
                    }
                }
                else if (tokens[0] == "Insert")
                {
                    int numberToInsert = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);

                    if (indexToInsert > numbers.Count - 1 || indexToInsert < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(indexToInsert, numberToInsert);
                    }
                }
                else if (tokens[0] == "Shift")
                {
                    int count = int.Parse(tokens[2]);

                    if (tokens[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if (tokens[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count  -1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }


    }
}
