using System;

namespace _1._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string commands = Console.ReadLine();

            while (commands != "Decode")
            {
                string[] tokens = commands.Split("|", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Move":
                        input = Move(input, tokens);
                        break;
                    case "Insert":
                        input = Insert(input, tokens);
                        break;
                    case "ChangeAll":
                        input = ChangeAll(input, tokens);
                        break;
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }

        private static string Move(string input, string[] tokens)
        {
            int index = int.Parse(tokens[1]);
            input = input.Remove(0, index) + input.Substring(0, index);

            return input;
        }

        private static string Insert(string input, string[] tokens)
        {
            int index = int.Parse(tokens[1]);
            string value = tokens[2];
            input = input.Insert(index, value);

            return input;
        }

        private static string ChangeAll(string input, string[] tokens)
        {
            string substring = tokens[1];
            string replacement = tokens[2];
            input = input.Replace(substring, replacement);

            return input;
        }
    }
}
