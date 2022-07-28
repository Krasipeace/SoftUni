using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<symbols>[\D]+)(?<repeater>[\d]+)";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                string symbols = match.Groups["symbols"].Value.ToString().ToUpper();
                int repeater = int.Parse(match.Groups["repeater"].Value);

                for (int i = 0; i < repeater; i++)
                {
                    output.Append(symbols);
                }
            }

            char[] symbolsCheck = output.ToString().ToCharArray();
            var listSymbols = new List<char>();

            foreach (char currSymbol in symbolsCheck)
            {
                if (!listSymbols.Contains(currSymbol))
                {
                    listSymbols.Add(currSymbol);
                }
            }

            int counter = listSymbols.Count;

            Console.WriteLine($"Unique symbols used: {counter}");
            Console.WriteLine(output);
        }
    }
}
