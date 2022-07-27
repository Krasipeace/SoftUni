using System;
using System.Linq;

namespace _1._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string commands = Console.ReadLine();

            while (commands != "Reveal")
            {
                // :|:
                string[] tokens = commands.Split(":|:");
                // Change All
                switch (tokens[0])
                {
                    case "ChangeAll":
                    {
                        // to take the substring that need to be replaced
                        string substring = tokens[1]; // V
                        // take the replacement string
                        string replacement = tokens[2];
                        message = message.Replace(substring, replacement);
                    }
                        break;
                    case "Reverse":
                    {
                            // Reverse=[0], {substring}= [1]
                            // substring = !gnil
                            string substring = tokens[1];
                        if (message.Contains(substring))
                        {
                            // hellodar!gnil
                            int index = message.IndexOf(substring);
                            message = message.Remove(index, substring.Length);

                            //ling!
                            message = $"{message}{string.Join("", substring.Reverse())}";
                        }
                        else
                        {
                            Console.WriteLine("error");
                            commands = Console.ReadLine();
                            continue;
                        }                        
                    }
                        break;
                    case "InsertSpace":
                    {
                        int index = int.Parse(tokens[1]);
                        message = message.Insert(index, " ");                        
                    }
                        break;
                }

                Console.WriteLine(message);

                commands = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
