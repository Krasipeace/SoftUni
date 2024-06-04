using System;
using System.Linq;

namespace _2.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            
            PrintVowels(input);
        }

        private static void PrintVowels(string input)
        {
            int counter = 0;
            foreach (char vowel in input)
            {
                if ("aoeui".Contains(vowel))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
