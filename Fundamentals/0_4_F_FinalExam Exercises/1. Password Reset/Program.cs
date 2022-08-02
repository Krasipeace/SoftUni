using System;
using System.Text;

namespace _1._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder password = new StringBuilder();

            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] action = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (action[0])
                {
                    case "TakeOdd":
                        {
                            for (int i = 0; i < input.Length; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    password.Append(input[i]);
                                }
                            }

                            input = password.ToString();
                            Console.WriteLine(input);
                        }
                        break;
                    case "Cut":
                        {
                            int index = int.Parse(action[1]);
                            int length = int.Parse(action[2]);

                            input = input.Remove(index, length);

                            Console.WriteLine(input);
                        }
                        break;
                    case "Substitute":
                        {
                            string substring = action[1];
                            string substitute = action[2];

                            if (input.Contains(substring))
                            {
                                input = input.Replace(substring, substitute);

                                Console.WriteLine(input);
                            }
                            else
                            {
                                Console.WriteLine($"Nothing to replace!");
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {input}");
        }
    }
}
