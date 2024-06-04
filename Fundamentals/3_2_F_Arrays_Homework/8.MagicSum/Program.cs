using System;
using System.Linq;

namespace _8.MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();
            int key = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length - 1; i++)
            {
                int currentNumber = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (currentNumber + array[j] == key)
                    {
                        Console.WriteLine($"{currentNumber} {array[j]}");
                    }
                }
            }
        }
    }
}
