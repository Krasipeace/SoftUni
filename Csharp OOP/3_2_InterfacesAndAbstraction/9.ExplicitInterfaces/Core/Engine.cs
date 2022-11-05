namespace ExplicitInterfaces.Core
{
    using System;

    using ExplicitInterfaces.Core.Contracts;
    using ExplicitInterfaces.Models;
    using ExplicitInterfaces.Models.Contracts;

    public class Engine : IEngine
    {
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string country = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
