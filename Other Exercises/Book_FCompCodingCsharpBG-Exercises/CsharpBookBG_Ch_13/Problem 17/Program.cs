using System;
using System.Text.RegularExpressions;

namespace Problem_17 //task 19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();

            string pattern = @"([a-zA-Z0-9._-]{3,}@([a-zA-Z0-9_-]+\.)+[a-zA-Z0-9_-]+)";

            MatchCollection email = Regex.Matches(text, pattern);

            foreach (var item in email)
            {
                Console.WriteLine(item);
            }
        }
    }
}
