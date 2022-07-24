using System;
using System.Text.RegularExpressions;

namespace Problem_18 //task 20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string text = Console.ReadLine();

            string pattern = @"[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{4}\b";

            MatchCollection date = Regex.Matches(text, pattern);

            foreach (var patternDate in date)
            {
                Console.WriteLine(patternDate);
            }
        }
    }
}
