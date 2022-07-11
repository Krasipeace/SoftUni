using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> contestResults = new Dictionary<string, Dictionary<string, int>>();

            AddContests(contests);

            ReadSubmissions(contests, contestResults);

            PrintBestStudent(contestResults);

            PrintStudents(contestResults);
        }

        private static void AddContests(Dictionary<string, string> contests)
        {
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                if (input.Contains(':'))
                {
                    string[] inputContest = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    string contestName = inputContest[0];
                    string contestPass = inputContest[1];

                    if (!contests.ContainsKey(contestName))
                    {
                        contests.Add(contestName, contestPass);
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void ReadSubmissions(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> contestResults)
        {
            string input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] inputSubmission = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = inputSubmission[0];
                string password = inputSubmission[1];
                string studentName = inputSubmission[2];
                int points = int.Parse(inputSubmission[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!contestResults.ContainsKey(studentName))
                    {
                        contestResults.Add(studentName, new Dictionary<string, int>());
                    }

                    if (!contestResults[studentName].ContainsKey(contest))
                    {
                        contestResults[studentName].Add(contest, 0);
                    }

                    if (contestResults[studentName][contest] < points)
                    {
                        contestResults[studentName][contest] = points;
                    }

                }
                input = Console.ReadLine();
            }
        }

        private static void PrintBestStudent(Dictionary<string, Dictionary<string, int>> contestResults)
        {
            foreach (var user in contestResults.OrderByDescending(p => p.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value.Values.Sum()} points.");

                return;
            }
        }

        private static void PrintStudents(Dictionary<string, Dictionary<string, int>> contestResults)
        {
            Console.WriteLine("Ranking: ");
            foreach (var student in contestResults.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{student.Key}");

                foreach (var points in student.Value.OrderByDescending(points => points.Value))
                {
                    Console.WriteLine($"#  {points.Key} -> {points.Value}");
                }
            }
        }
    }
}
