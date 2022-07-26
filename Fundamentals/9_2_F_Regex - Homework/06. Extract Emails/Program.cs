using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            string text = Console.ReadLine();

            string pattern = @"(^|\s)[A-Za-z0-9][\w*\.\-]*[A-Za-z0-9]@[A-Za-z0-9]+([.-][A-Za-z]+)+\b";

            MatchCollection email = Regex.Matches(text, pattern);

            email.ToList().ForEach(Console.WriteLine);
        }
    }
}
