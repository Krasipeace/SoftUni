using System;
using System.Text;

namespace _1._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();
            output.Append(input);

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Add Stop":
                        AddStop(output, tokens);
                        break;
                    case "Remove Stop":
                        RemoveStop(output, tokens);
                        break;
                    case "Switch":
                        SwitchStops(output, tokens);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {output}");
        }

        private static void AddStop(StringBuilder output, string[] tokens)
        {
            int index = int.Parse(tokens[1]);
            string addStop = tokens[2];

            if (index >= 0 && index < output.Length)
            {
                output.Insert(index, addStop);
            }

            Console.WriteLine(output);
        }

        private static void RemoveStop(StringBuilder output, string[] tokens)
        {
            int startIndex = int.Parse(tokens[1]);
            int endIndex = int.Parse(tokens[2]);

            if (startIndex >= 0 && startIndex < output.Length && endIndex >= 0 && endIndex < output.Length)
            {
                output.Remove(startIndex, (endIndex + 1) - startIndex);
            }

            Console.WriteLine(output);
        }

        private static void SwitchStops(StringBuilder output, string[] tokens)
        {
            string oldString = tokens[1];
            string newString = tokens[2];

            if (output.ToString().Contains(oldString))
            {
                output.Replace(oldString, newString);
            }

            Console.WriteLine(output);
        }
    }
}
