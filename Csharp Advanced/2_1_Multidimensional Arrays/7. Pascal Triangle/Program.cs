using System;
using System.Linq;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputHeight = int.Parse(Console.ReadLine());

            ulong[][] triangle = new ulong[inputHeight][];

            for (int row = 0; row < inputHeight; row++)
            {
                triangle[row] = new ulong[row + 1];

                for (int col = 0; col < row + 1; col++)
                {
                    ulong sum = 0;
                    if (row - 1 >= 0 && col < triangle[row - 1].Length)
                    {
                        sum += triangle[row - 1][col];
                    }

                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        sum += triangle[row - 1][col - 1];
                    }

                    if (sum == 0)
                    {
                        sum = 1;
                    }

                    triangle[row][col] = sum;
                }
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    Console.Write($"{triangle[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
