using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Mirror_Worlds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\@|\#)(?<wordOne>[A-Za-z]{3,})(\1)(\1)(?<wordTwo>[A-Za-z]{3,})(\1)";

            string input = Console.ReadLine();

            MatchCollection matchWordPairs = Regex.Matches(input, pattern);

            if (matchWordPairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchWordPairs.Count} word pairs found!");
            }

            StringBuilder stringBuilder = new StringBuilder();
            int counter = 0;

            foreach (Match wordPair in matchWordPairs)
            {
                string wordOne = wordPair.Groups["wordOne"].Value;
                string wordTwo = wordPair.Groups["wordTwo"].Value;

                string reversedWordTwo = ReversingWord(wordTwo);

                if (string.Equals(wordOne, reversedWordTwo))
                {
                    stringBuilder.Append($"{wordOne} <=> {wordTwo}, ");
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                stringBuilder.Length = stringBuilder.Length - 2;  //removing the last ", " from the line
                Console.WriteLine(stringBuilder);
            }


        }

        private static string ReversingWord(string wordTwo)
        {
            char[] reversingLetters = wordTwo.ToCharArray();
            Array.Reverse(reversingLetters);

            return new string(reversingLetters);
        }
    }
}
