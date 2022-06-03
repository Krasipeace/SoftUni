using System;
using System.Linq;

namespace _9.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int[] arrayBestDNA = new int[length];
            int maxOnes = 0;
            int bestSequenceIndex = 0;
            int bestSequenceSum = 0;
            int currentDNA = 0;
            int bestDNA = 0;

            while (command != "Clone them!")
            {
                int[] currentArray = command.Split("!".ToCharArray())
                                            .Select(int.Parse)
                                            .ToArray();
                int countOfOnes = 0;
                int currentMaxOnes = 0;
                int index = 0;
                int currentBestIndex = -1;

                for (int currentIndex = 0; currentIndex < currentArray.Length; currentIndex++)
                {
                    if (currentArray[currentIndex] == 1)
                    {
                        countOfOnes++;
                        if (countOfOnes == 1)
                        {
                            index = currentIndex;
                        }
                    }
                    else
                    {
                        if (countOfOnes > currentMaxOnes)
                        {
                            currentMaxOnes = countOfOnes;
                            currentBestIndex = index;
                        }
                        countOfOnes = 0;
                    }
                }
                currentDNA++;

                if (currentDNA == 1 || currentMaxOnes > maxOnes || currentBestIndex < bestSequenceIndex || currentArray.Sum() > bestSequenceSum)
                {
                    maxOnes = currentMaxOnes;
                    bestSequenceIndex = currentBestIndex;
                    bestSequenceSum = currentArray.Sum();
                    bestDNA = currentDNA;
                    arrayBestDNA = currentArray;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestDNA} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(' ', arrayBestDNA));


            // unfinished
        }
    }
}
