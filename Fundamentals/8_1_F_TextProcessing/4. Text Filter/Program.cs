using System;

namespace _4._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] censoredWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var censoredWord in censoredWords)
            {
                string censoringSymbol = new string('*', censoredWord.Length);

                text = text.Replace(censoredWord, censoringSymbol);
            }

            Console.WriteLine(text);
        }
    }
}