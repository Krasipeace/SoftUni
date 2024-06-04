using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Predicate_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Func<List<string>, string, List<string>> startsWith = (list, command) => list.FindAll(x => x.StartsWith(command));
            Func<List<string>, string, List<string>> endsWith = (list, command) => list.FindAll(x => x.EndsWith(command));
            Func<List<string>, string, List<string>> changeLength = (list, command) => list.FindAll(x => x.Length == int.Parse(command));

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                FilterNames(names, startsWith, endsWith, changeLength, tokens);

                command = Console.ReadLine();
            }

            PrintNames(names);
        }

        static void FilterNames(List<string> names, Func<List<string>, string, List<string>> startsWith, Func<List<string>, string, List<string>> endsWith, Func<List<string>, string, List<string>> changeLength, string[] tokens)
        {
            switch (tokens[1])
            {
                case "StartsWith":
                    {
                        FilterNameStartsWith(names, startsWith, tokens);
                        break;
                    }
                case "EndsWith":
                    {
                        FilterNameEndsWith(names, endsWith, tokens);
                        break;
                    }
                case "Length":
                    {
                        FilterLengthOfName(names, changeLength, tokens);
                        break;
                    }
            }
        }

        static void FilterNameStartsWith(List<string> names, Func<List<string>, string, List<string>> startsWith, string[] tokens)
        {
            if (tokens[0] == "Double")
            {
                names.AddRange(startsWith(names, tokens[2]));
            }
            else if (tokens[0] == "Remove")
            {
                startsWith(names, tokens[2]).ForEach(x => names.Remove(x));
            }
        }

        static void FilterNameEndsWith(List<string> names, Func<List<string>, string, List<string>> endsWith, string[] tokens)
        {
            if (tokens[0] == "Double")
            {
                names.AddRange(endsWith(names, tokens[2]));
            }
            else if (tokens[0] == "Remove")
            {
                endsWith(names, tokens[2]).ForEach(x => names.Remove(x));
            }
        }

        static void FilterLengthOfName(List<string> names, Func<List<string>, string, List<string>> changeLength, string[] tokens)
        {
            if (tokens[0] == "Double")
            {
                names.AddRange(changeLength(names, tokens[2]));
            }
            else if (tokens[0] == "Remove")
            {
                changeLength(names, tokens[2]).ForEach(x => names.Remove(x));
            }
        }

        static void PrintNames(List<string> names)
        {
            Action<List<string>> print = list => Console.WriteLine($"{string.Join(", ", list)} are going to the party!");

            if (names.Count != 0)
            {
                print(names);
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
