using System;
using System.Text;

namespace _1._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder activationKey = new StringBuilder();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Generate")
                {
                    break;
                }
                string[] action = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                switch (action[0])
                {
                    case "Contains":
                        Contains(action, input, activationKey);
                        break;
                    case "Flip":
                        input = FlipUpperOrLower(input, action);
                        break;
                    case "Slice":
                        input = Slice(input, action);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {input}");
        }



        private static void Contains(string[] action, string input, StringBuilder activationKey)
        {
            string substring = action[1];

            if (input.Contains(substring))
            {
                Console.WriteLine($"{input} contains {substring}");
            }
            else
            {
                Console.WriteLine($"Substring not found!");
            }
        }

        private static string FlipUpperOrLower(string input, string[] action)
        {
            switch (action[1])
            {
                case "Upper":
                        input = FlipToUpper(input, action);
                    break;
                case "Lower":
                        input = FlipToLower(input, action);
                    break;
            }

            return input;
        }

        private static string FlipToUpper(string input, string[] action)
        {
            int startIndex = int.Parse(action[2]);
            int endIndex = int.Parse(action[3]);

            int temp = endIndex - startIndex;
            string toUpper = input.Substring(startIndex, temp);
            input = input.Remove(startIndex, temp);
            toUpper = toUpper.ToUpper();
            input = input.Insert(startIndex, toUpper);

            Console.WriteLine(input);

            return input;
        }

        private static string FlipToLower(string input, string[] action)
        {
            int startIndex = int.Parse(action[2]);
            int endIndex = int.Parse(action[3]);

            int temp = endIndex - startIndex;
            string toLower = input.Substring(startIndex, temp);
            input = input.Remove(startIndex, temp);
            toLower = toLower.ToLower();
            input = input.Insert(startIndex, toLower);

            Console.WriteLine(input);

            return input;
        }

        private static string Slice(string input, string[] action)
        {
            int startIndex = int.Parse(action[1]);
            int endIndex = int.Parse(action[2]);

            int temp = endIndex - startIndex;
            input = input.Remove(startIndex, temp);
            Console.WriteLine(input);

            return input;
        }
    }
}
