using System;
using System.Collections.Generic;

namespace _5.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = FillPeople();

            int personNumber = int.Parse(Console.ReadLine());

            int counter = CountEqualPeople(people, personNumber);

            PrintStats(people, counter);
        }

        static List<Person> FillPeople()
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            return people;
        }

        static int CountEqualPeople(List<Person> people, int personNumber)
        {
            int counter = 0;
            for (int i = 0; i < people.Count; i++)
            {
                int result = people[personNumber - 1].CompareTo(people[i]);
                if (result == 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        static void PrintStats(List<Person> people, int counter)
        {
            string result;
            if (counter == 1)
            {
                result = "No matches";
            }
            else
            {
                result = $"{counter} {Math.Abs(counter - people.Count)} {people.Count}";
            }
            Console.WriteLine(result);
        }
    }
}
