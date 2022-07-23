using System;
using System.Text.RegularExpressions;

namespace Problem_11 //task 13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter URL: ");
            string input = Console.ReadLine();

            string pattern = @"\b(?<protocol>[A-Za-z]+\b)://(?<server>[A-Za-z]+.[A-Za-z]+)(?<resource>/\w+)+";

            MatchCollection urlMatch = Regex.Matches(input, pattern);

            foreach (Match match in urlMatch)
            {
                Console.WriteLine($"[protocol]: {match.Groups["protocol"].Value}");
                Console.WriteLine($"[server]: {match.Groups["server"].Value}");
                Console.WriteLine($"[resource]: {match.Groups["resource"].Value}");                 
            }
        }
    }
}
