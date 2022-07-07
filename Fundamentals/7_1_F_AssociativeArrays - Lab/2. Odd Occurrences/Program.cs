using System;
using System.Collections.Generic;

namespace _2._Odd_Occurrences
{
    //program that extracts all elements from a given sequence of words that are present in it an odd number of times (case-insensitive).
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordLowerCase = word.ToLower();

                if (counts.ContainsKey(wordLowerCase))
                {
                    counts[wordLowerCase]++;
                }
                else
                {
                    counts.Add(wordLowerCase, 1);
                }
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                { 
                Console.Write(count.Key + " ");
                }
            }
        }
    }
}
