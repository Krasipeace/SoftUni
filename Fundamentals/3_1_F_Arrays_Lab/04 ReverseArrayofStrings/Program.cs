using System;
using System.Linq;

namespace _04_ReverseArrayofStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int arrayLength = input.Length; 
            string[] reversedArray = new string[arrayLength];

            for (int index = 0; index < arrayLength; index++)
            {

                reversedArray[arrayLength - index - 1] = input[index];

            }

            for (int index = 0; index < arrayLength; index++)
            {

                Console.Write($"{reversedArray[index]} ");
            }
        }
    }
}
