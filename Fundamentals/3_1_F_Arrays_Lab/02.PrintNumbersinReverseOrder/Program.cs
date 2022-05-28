using System;

namespace _02.PrintNumbersinReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumbers = int.Parse(Console.ReadLine());
            int[] numbersArray = new int[inputNumbers];

            for (int i = 0; i < inputNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbersArray[i] = number;
            }
            for (int i = numbersArray.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbersArray[i]} ");
            }
        }
    }
}
