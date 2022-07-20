using System;
using System.Text.RegularExpressions;

namespace _3._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})([\-|\.|\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            MatchCollection dateMatches = Regex.Matches(date, pattern);

            foreach (Match eachDate in dateMatches)
            {
                Console.WriteLine($"Day: {eachDate.Groups["day"].Value}, Month: {eachDate.Groups["month"].Value}, Year: {eachDate.Groups["year"].Value}");
            }
        }
    }
}
