using System; //count words alphabetically from text
using System.Collections.Generic;
using System.Linq;

namespace Problem_21 //task 23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionWords = new Dictionary<string, int>();
            char[] separators = { ' ', '.', ',', ';', ':', '?', '!' };

            foreach (string word in words)
            {
                string eachWord = word.Trim().ToLower(); //or toUpper(); || remove and 1st upper letter then lower letters in the printed result

                if (!dictionWords.ContainsKey(eachWord))
                {
                    dictionWords.Add(eachWord, 1);
                }
                else
                {
                    dictionWords[eachWord] += 1;
                }
            }       

            Console.WriteLine($"Total word count: {dictionWords.Count}");

            var sortedKeys = dictionWords.Keys.ToList();
            sortedKeys.Sort();

            foreach (var eachWord in sortedKeys)
            {
                Console.WriteLine($"Total occurrences of {eachWord}: {dictionWords[eachWord]}");
            }
        }
    }
}
