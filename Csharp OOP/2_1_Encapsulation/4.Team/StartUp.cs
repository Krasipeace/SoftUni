using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));
                    persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Team team = new Team("SoftUni");           

            foreach (Person person in persons)
            {
                if (person.Age < 40)
                {
                    team.AddPlayer(person);
                }
                else
                {
                    team.AddPlayer(person);
                }
            }
            Console.WriteLine(team.ToString());
        }   
    }
}
