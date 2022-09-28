using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                UseFilters(filters, input);
                input = Console.ReadLine();
            }

            foreach (string[] commands in from filter in filters
                                          let commands = filter.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          select commands)
            {
                names = UseSubfilters(names, commands);
            }

            PrintResult(names);
        }

        static void UseFilters(List<string> filters, string input)
        {
            string[] commands = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (commands[0])
            {
                case "Add filter":
                    filters.Add(commands[1] + " " + commands[2]);
                    break;
                case "Remove filter":
                    filters.Remove(commands[1] + " " + commands[2]);
                    break;
            }
        }

        static List<string> UseSubfilters(List<string> names, string[] commands)
        {
            switch (commands[0])
            {
                case "Starts":
                    {
                        names = names.Where(n => !n.StartsWith(commands[2])).ToList();
                        break;
                    }
                case "Ends":
                    {
                        names = names.Where(n => !n.EndsWith(commands[2])).ToList();
                        break;
                    }
                case "Length":
                    {
                        names = names.Where(n => n.Length != int.Parse(commands[1])).ToList();
                        break;
                    }
                case "Contains":
                    {
                        names = names.Where(n => !n.Contains(commands[1])).ToList();
                        break;
                    }
            }

            return names;
        }
        static void PrintResult(List<string> names)
        {
            if (names.Any())
            {
                Console.WriteLine(string.Join(" ", names));
            }
        }
    }
}
