using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\=|\/])(?<location>[A-Z][A-Za-z]{2,})\1";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);
            int lengthCounter = 0;
            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                string validLocation = match.Groups["location"].Value;
                lengthCounter += validLocation.Length;
                output.Append($"{validLocation}, ");
            }
            if (lengthCounter > 2)
            {
                output.Length = output.Length - 2;
                Console.WriteLine($"Destinations: {output}");
                Console.WriteLine($"Travel Points: {lengthCounter}");
            }
            else
            {
                Console.WriteLine($"Destinations: {output}");
                Console.WriteLine($"Travel Points: {lengthCounter}");
            }
        }
    }
}
