using System;
using System.Collections.Generic;

namespace _7._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            input = SolvingTask(info, input);

            PrintResult(info);
        }

        private static string SolvingTask(Dictionary<string, List<string>> info, string input)
        {
            while (true)
            {
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string companyName = tokens[0];
                string employeeId = tokens[1];

                if (!info.ContainsKey(companyName))
                {
                    info.Add(companyName, new List<string>());
                }
                else
                {
                    if (info[companyName].Contains(employeeId))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }
                info[companyName].Add(employeeId);

                input = Console.ReadLine();
            }

            return input;
        }

        private static void PrintResult(Dictionary<string, List<string>> info)
        {
            foreach (var item in info)
            {
                Console.WriteLine(item.Key);
                foreach (var employeeId in item.Value)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }
    }
}
