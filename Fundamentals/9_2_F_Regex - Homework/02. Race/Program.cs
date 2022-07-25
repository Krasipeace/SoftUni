using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> participants = new Dictionary<string, int>();

            Regex patternNames = new Regex(@"(?<name>[A-Za-z]+)");
            Regex patternDistance = new Regex (@"(?<distance>\d+)");

            int sumDigits = 0;

            string input = Console.ReadLine();
            while(true)
            {
                if (input == "end of race")
                {
                    break;
                }

                MatchCollection matchesNames = patternNames.Matches(input);
                MatchCollection matchesDistance = patternDistance.Matches(input);

                string currentName = string.Join("", matchesNames);
                string currentDistance = string.Join("", matchesDistance);

                sumDigits = 0;
                for (int i = 0; i < currentDistance.Length; i++)
                {
                    sumDigits += int.Parse(currentDistance[i].ToString());
                }

                if (names.Contains(currentName)) 
                {
                    if (!participants.ContainsKey(currentName)) //if currentName doesnt exist in the list, add it.
                    {
                        participants.Add(currentName, sumDigits);
                    }
                    else                                        //else currentName distance run.   
                    {
                        participants[currentName] += sumDigits; 
                    }
                }

                input = Console.ReadLine();
            }

            var winners = participants.OrderByDescending(w => w.Value).Take(3); //take 1st 3 runners by their most distance run.

            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(w2 => w2.Value).Take(2).OrderBy(w2 => w2.Value).Take(1);
            var theirdPlace = winners.OrderBy(w3 => w3.Value).Take(1);

            foreach (var name in firstPlace)
            {
                Console.WriteLine($"1st place: {name.Key}");
            }
            foreach (var name in secondPlace)
            {
                Console.WriteLine($"2nd place: {name.Key}");
            }
            foreach (var name in theirdPlace)
            {
                Console.WriteLine($"3rd place: {name.Key}");
            }
        }
    }
}
