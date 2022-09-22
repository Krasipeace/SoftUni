using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, int> data = new Dictionary<string, int>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            List<(string name, int age)> data = new List<(string name, int age)>();

            Func<(string name, int age), int, bool> caseYoung = (person, age) => person.age < age;
            Func<(string name, int age), int, bool> caseOlder = (person, age) => person.age >= age;

            ReadPeople(numberOfInputs, data);

            string condition = Console.ReadLine();
            int checkAge = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            data = FilterByCondition(data, caseYoung, caseOlder, condition, checkAge);

            PrintPeople(data, format);
        }

        static void ReadPeople(int numberOfInputs, List<(string name, int age)> data)
        {
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                data.Add((name, age));
            }
        }

        static List<(string name, int age)> FilterByCondition(List<(string name, int age)> data, Func<(string name, int age), int, bool> caseYoung, Func<(string name, int age), int, bool> caseOlder, string condition, int checkAge)
        {
            switch (condition)
            {
                case "younger":
                    data = data.Where(n => caseYoung(n, checkAge)).ToList();
                    break;
                case "older":
                    data = data.Where(n => caseOlder(n, checkAge)).ToList();
                    break;
            }

            return data;
        }

        static void PrintPeople(List<(string name, int age)> data, string[] format)
        {
            foreach (var (person, output) in from person in data
                                             let output = new List<string>()
                                             select (person, output))
            {
                if (format.Contains("name"))
                {
                    output.Add(person.name);
                }

                if (format.Contains("age"))
                {
                    output.Add(person.age.ToString());
                }

                Console.WriteLine(string.Join(" - ", output));
            }
        }
    }
}
