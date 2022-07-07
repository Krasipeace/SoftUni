using System;
using System.Collections.Generic;

namespace _1._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> word = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }
                char letter = input[i];

                if (!word.ContainsKey(letter))
                {
                    word[letter] = 0;
                }
                word[letter] += 1;
            }

            foreach (var chr in word)
            {
                Console.WriteLine($"{chr.Key} -> {chr.Value}");
            }
        }
    }
}
