namespace BorderControl.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using BorderControl.Models.Interfaces;
    using BorderControl.Models;

    public class BirthdayCheck : IEngine
    {
        private List<IBirthdate> birthdates;

        public void RunEngine()
        {
            birthdates = new List<IBirthdate>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] dataInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string creature = dataInfo[0];
                string name = dataInfo[1];

                switch (creature)
                {
                    case "Citizen":
                        birthdates.Add(new Citizen(name, int.Parse(dataInfo[2]), dataInfo[3], dataInfo[4]));
                        break;
                    case "Pet":
                        birthdates.Add(new Pet(name, dataInfo[2]));
                        break;
                }

                input = Console.ReadLine();
            }

            string yearOfBirth = Console.ReadLine();
            foreach (var item in birthdates.Select(x => x.Birthdate).Where(y => y.EndsWith(yearOfBirth)))
            {
                Console.WriteLine(item);
            }
        }
    }
}
