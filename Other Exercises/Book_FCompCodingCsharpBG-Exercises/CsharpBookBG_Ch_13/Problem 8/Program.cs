using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string[] text = Console.ReadLine().Split(".", StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Search for: ");
            string searchWord = Console.ReadLine();

            string pattern = $@"\b{searchWord}\b";
            Regex regex = new Regex(pattern);

            string newText = string.Empty;
            string[] matches = new string[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                newText = text[i];
                if (regex.IsMatch(newText))
                {
                    matches[i] = newText;
                }
            }

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
            




        }
    }
}
