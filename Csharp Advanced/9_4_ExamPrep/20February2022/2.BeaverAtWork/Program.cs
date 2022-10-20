using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char EMPTY_POS = '-';
            const char BEAVER_POS = 'B';
            const char FISH_POS = 'F';

            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int currentRow = 0;
            int currentCol = 0;
            int branchesLeft = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == BEAVER_POS)
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (char.IsLetter(line[col]) && char.IsLower(line[col]))
                    {
                        branchesLeft++;
                    }
                }
            }
            List<char> collectedBranches = new List<char>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "up":
                        if (currentRow - 1 >= 0)
                        {
                            matrix[currentRow, currentCol] = EMPTY_POS;
                            currentRow--;

                            if (matrix[currentRow, currentCol] == FISH_POS)
                            {
                                matrix[currentRow, currentCol] = EMPTY_POS;

                                if (currentRow - 1 != 0)
                                {
                                    currentRow = matrixSize - 1;
                                }
                                else
                                {
                                    currentRow = 0;
                                }
                                branchesLeft = CheckForBranch(matrix, currentRow, currentCol, branchesLeft, collectedBranches);
                            }
                            else
                            {
                                branchesLeft = CheckForBranch(matrix, currentRow, currentCol, branchesLeft, collectedBranches);
                            }
                        }
                        else
                        {
                            if (collectedBranches.Count > 0)
                            {
                                collectedBranches.RemoveAt(collectedBranches.Count - 1);
                            }
                        }
                        break;
                    case "down":
                        if (currentRow + 1 < matrixSize)
                        {
                            matrix[currentRow, currentCol] = EMPTY_POS;
                            currentRow++;

                            if (matrix[currentRow, currentCol] == FISH_POS)
                            {
                                matrix[currentRow, currentCol] = EMPTY_POS;
                                if (currentRow + 1 != 0)
                                {
                                    currentRow = 0;
                                }
                                else
                                {
                                    currentRow = matrixSize - 1;
                                }
                            }
                            branchesLeft = CheckForBranch(matrix, currentRow, currentCol, branchesLeft, collectedBranches);
                        }
                        else
                        {
                            if (collectedBranches.Count > 0)
                            {
                                collectedBranches.RemoveAt(collectedBranches.Count - 1);
                            }
                        }
                        break;
                    case "left":
                        if (currentCol - 1 >= 0)
                        {
                            matrix[currentRow, currentCol] = EMPTY_POS;
                            currentCol--;

                            if (matrix[currentRow, currentCol] == FISH_POS)
                            {
                                matrix[currentRow, currentCol] = EMPTY_POS;
                                if (currentCol - 1 != 0)
                                {
                                    currentCol = matrixSize - 1;
                                }
                                else
                                {
                                    currentCol = 0;
                                }
                            }
                            branchesLeft = CheckForBranch(matrix, currentRow, currentCol, branchesLeft, collectedBranches);
                        }
                        else
                        {
                            if (collectedBranches.Count > 0)
                            {
                                collectedBranches.RemoveAt(collectedBranches.Count - 1);
                            }
                        }
                        break;
                    case "right":
                        if (currentCol + 1 < matrixSize)
                        {
                            matrix[currentRow, currentCol] = EMPTY_POS;
                            currentCol++;

                            if (matrix[currentRow, currentCol] == FISH_POS)
                            {
                                matrix[currentRow, currentCol] = EMPTY_POS;
                                if (currentCol + 1 != 0)
                                {
                                    currentCol = matrixSize - 1;
                                }
                                else
                                {
                                    currentCol = 0;
                                }
                            }
                            branchesLeft = CheckForBranch(matrix, currentRow, currentCol, branchesLeft, collectedBranches);
                        }
                        else
                        {
                            if (collectedBranches.Count > 0)
                            {
                                collectedBranches.RemoveAt(collectedBranches.Count - 1);
                            }
                        }
                        break;
                }
                matrix[currentRow, currentCol] = BEAVER_POS;
                if (branchesLeft == 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            PrintResults(matrixSize, matrix, branchesLeft, collectedBranches);
        }

        static int CheckForBranch(char[,] matrix, int currentRow, int currentCol, int branchesLeft, List<char> collectedBranches)
        {
            if (char.IsLetter(matrix[currentRow, currentCol]) && char.IsLower(matrix[currentRow, currentCol]))
            {
                collectedBranches.Add(matrix[currentRow, currentCol]);
                branchesLeft--;
            }

            return branchesLeft;
        }

        static void PrintResults(int matrixSize, char[,] matrix, int branchesLeft, List<char> collectedBranches)
        {
            if (branchesLeft == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesLeft} branches left.");
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
