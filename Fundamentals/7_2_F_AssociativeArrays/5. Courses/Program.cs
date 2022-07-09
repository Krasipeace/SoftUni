using System;
using System.Collections.Generic;

namespace _5._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "end")
                {
                    break;
                }
                string[] tokens = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string courseName = tokens[0];
                string studentName = tokens[1];

                if(!info.ContainsKey(courseName))
                {
                    info[courseName] = new List<string>();
                }
                info[courseName].Add(studentName);

                input = Console.ReadLine();
            }

            PrintResult(info);
        }

        private static void PrintResult(Dictionary<string, List<string>> info)
        {
            foreach (var item in info)
            {
                string courseName = item.Key;
                var students = item.Value;

                Console.WriteLine($"{courseName}: {students.Count}");

                foreach (var student in students)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
