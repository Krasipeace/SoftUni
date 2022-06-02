using System;
using System.Linq;

namespace _3.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] arrayOne = new int[length];
            int[] arrayTwo = new int[length];

            for (int i = 0; i < length; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    arrayOne[i] = input[0];
                    arrayTwo[i] = input[1];
                }
                else
                {
                    arrayTwo[i] = input[0];
                    arrayOne[i] = input[1];
                }
            }

            Console.WriteLine(string.Join(" ", arrayOne));
            Console.WriteLine(string.Join(" ", arrayTwo));
        }
    }
}
