using System;
using System.Text.RegularExpressions;

namespace _1._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match item in matches)
            {
                Console.Write($"{item.Value} ");
            }
        }
    }
}
