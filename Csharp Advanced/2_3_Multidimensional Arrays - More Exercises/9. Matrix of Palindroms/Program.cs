using System;
using System.Linq;

namespace _9._Matrix_of_Palindroms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int PALINDROME_RANGE = 3;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";         

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < PALINDROME_RANGE; i++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                          matrix[row,col] = $"{(char)(alphabet[0] + row)}{(char)(alphabet[0] + row + col)}{(char)(alphabet[0] + row)}";
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row,col]} "); 
                }
                Console.WriteLine();
            }
        }
    }
}
