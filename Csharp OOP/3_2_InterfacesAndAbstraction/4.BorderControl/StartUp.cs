namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Models.Interfaces;
    
    public class StartUp
    {
        public static List<IIdentify> identifications;
        static void Main(string[] args)
        {
            RunEngine();
        }

        private static void RunEngine()
        {
            identifications = new List<IIdentify>();

            string input = Console.ReadLine();
            input = GetIdentifications(input);

            string detainedId = Console.ReadLine();

            PrintResult(detainedId);
        }

        private static string GetIdentifications(string input)
        {
            while (input != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                if (tokens.Length > 2)
                {
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    identifications.Add(new Citizen(name, age, id));
                }
                else
                {
                    string id = tokens[1];
                    identifications.Add(new Robot(name, id));
                }

                input = Console.ReadLine();
            }

            return input;
        }

        private static void PrintResult(string detainedId)
        {
            foreach (var item in identifications.Select(x => x.Id).Where(y => y.EndsWith(detainedId)))
            {
                Console.WriteLine(item);
            }
        }
    }
}
