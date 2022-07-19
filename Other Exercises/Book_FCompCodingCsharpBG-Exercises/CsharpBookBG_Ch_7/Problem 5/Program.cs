using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5
{
    //{3, 2, 3, 4, 2, 2, 4} >>>> {2, 3, 4}.
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] maxSequence;
            int[] len = new int[sequence.Length];
            int[] prev = new int[sequence.Length];
            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && len[j] >= len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }

            maxSequence = new int[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                maxSequence[i] = sequence[lastIndex];
                lastIndex = prev[lastIndex];
            }

            Array.Reverse(maxSequence);
            Console.WriteLine(string.Join(", ", maxSequence));
        }
    }
}
