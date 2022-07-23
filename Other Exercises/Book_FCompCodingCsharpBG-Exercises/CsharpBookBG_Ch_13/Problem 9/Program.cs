using System;
using System.Text;

namespace Problem_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            Console.Write("Enter words for censor: ");
            string[] censoredWord = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in censoredWord)
            {
                string censoringSymbols = new string('*', word.Length);

                text = text.Replace(word, censoringSymbols);
            }

            Console.WriteLine(text);
        }
    }
}
