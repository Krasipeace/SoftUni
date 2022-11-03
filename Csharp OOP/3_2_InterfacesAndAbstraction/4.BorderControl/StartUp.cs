namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    
    public class StartUp
    {
        public static List<IIdentify> identifications;
        static void Main(string[] args)
        {
            identifications = new List<IIdentify>();

            string input = Console.ReadLine();
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

            string detainedId = Console.ReadLine();

            foreach (var item in identifications.Select(x => x.Id).Where(y => y.EndsWith(detainedId)))
            {
                Console.WriteLine(item);
            }
        }
    }
}
