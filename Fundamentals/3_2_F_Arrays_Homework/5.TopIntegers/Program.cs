using System;
using System.Linq;

namespace _5.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                         .Split()
                         .Select(int.Parse)
                         .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                bool isMax = true;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] <= array[j])
                    {
                        isMax = false;
                    }                    
                }

                if (isMax)
                {
                    Console.Write($"{array[i]} ");
                }    
            }         
        }
    }
}
