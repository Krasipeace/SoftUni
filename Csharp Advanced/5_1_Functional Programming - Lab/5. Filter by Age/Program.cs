using System;
using System.Collections.Generic;

namespace _5._Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, int> data = new Dictionary<string, int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                data.Add(name, age);
            }

            string condition = Console.ReadLine();
            int checkAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, checkAge);

            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudent(data, tester, printer);
        }


        private static Func<int, bool> CreateTester(string condition, int checkAge)
        {
            switch (condition)
            {
                case "older":
                    return x => x >= checkAge;
                case "younger":
                    return x => x < checkAge;
                default: return null;

            }
        }
        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default: return null;
            }
        }
        private static void PrintFilteredStudent(Dictionary<string, int> data, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in data)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
