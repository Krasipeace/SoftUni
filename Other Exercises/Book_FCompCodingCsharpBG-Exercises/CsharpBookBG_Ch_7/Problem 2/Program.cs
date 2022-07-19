using System;
using System.Linq;

namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter elements of array One: ");
            int[] arrayOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.Write("Enter elements of array Two: ");
            int[] arrayTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine();

            bool isArraysEqual = false;

            if (arrayOne.Length != arrayTwo.Length)
            {
                Console.WriteLine("Arrays are not equal!");

                return;
            }
            else
            {
                Array.Sort(arrayOne);
                Array.Sort(arrayTwo);

                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] != arrayTwo[i])
                    {
                        Console.WriteLine("Arrays are not equal!");

                        return;
                    }
                    else
                    {
                        isArraysEqual = true;
                    }
                }
            }
            if (isArraysEqual)
            {
                Console.WriteLine("Arrays are equal!");
            }
        }
    }
}
