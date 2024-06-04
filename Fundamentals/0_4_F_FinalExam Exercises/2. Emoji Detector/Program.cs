using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternAnimal = @"([\*)]{2,2}|[\:]{2,2})(?<word>[A-Z][a-z]{2,})(\1)";
            string patternCool = @"\d";

            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, patternAnimal);
            MatchCollection matchesCool = Regex.Matches(text, patternCool);

            int coolMatch = 1;  //multiplying by 0 = error...big error :D

            foreach (Match item in matchesCool)
            {
                int number = int.Parse(item.Value);
                coolMatch *= number;
            }

            Console.WriteLine($"Cool threshold: {coolMatch}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match matchEmoji in matches)
            {
                string emoji = matchEmoji.Groups["word"].Value;
                int CoolRank = emoji.ToCharArray().Sum(currChar => currChar);

                if (CoolRank >= coolMatch)
                {
                    Console.WriteLine(matchEmoji.Value);
                }
            }
        }
    }
}
